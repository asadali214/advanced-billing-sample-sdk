using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MaxioAdvancedBilling.Core.Authentication;
using MaxioAdvancedBilling.Core.ErrorResponse;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;
using MaxioAdvancedBilling.Core.Request;
using MaxioAdvancedBilling.Core.Response;

namespace MaxioAdvancedBilling.Core;

internal sealed class RawClient
{
    private readonly HeadersFactory _headerFactory;
    private readonly HttpClient _httpClient;
    private readonly HttpStatusPolicy _statusPolicy;
    private readonly UriFactory _uriFactory;
    private readonly ResiliencePipelineFactory _resiliencePipelineFactory;

    public RawClient(HttpClient httpClient, UriFactory uriFactory,
        HttpStatusPolicy statusPolicy, HeadersFactory headerFactory, ResiliencePipelineFactory resiliencePipelineFactory)
    {
        _httpClient = httpClient;
        _uriFactory = uriFactory;
        _statusPolicy = statusPolicy;
        _headerFactory = headerFactory;
        _resiliencePipelineFactory = resiliencePipelineFactory;
    }

    public async Task<ApiResult<TResponse, TError>> ExecuteResult<TResponse, TError>(
        UrlTemplate urlTemplate,
        IReadOnlyCollection<TemplateParam> templateParameters,
        IReadOnlyCollection<Param> queryParameters,
        IReadOnlyCollection<HeaderParam> headerParameters,
        HttpMethod httpMethod,
        IRequest request,
        IResponse<TResponse> response,
        IErrorResponse<TError> errorResponseDeserializer,
        IReadOnlyList<IAuthScheme> authPolicies,
        CancellationToken cancellationToken)
    {
        var uri = _uriFactory.Create(urlTemplate, queryParameters, templateParameters);
        var headers = _headerFactory.Create(headerParameters);

        var pipeline = _resiliencePipelineFactory.Create(request);

        // Execute request with retry policy. The response is NOT wrapped in `using` here: on success its
        // lifetime is owned by IResponse.Map (which disposes a buffered body immediately, or hands the
        // response to the streaming iterator it returns). The error path below owns disposal explicitly.
        var httpResponseMessage = await pipeline.ExecuteAsync(async ct =>
        {
            using var httpRequest = new HttpRequestMessage(httpMethod, uri);
            httpRequest.Content = request.Get();
            httpRequest.Headers.AddRange(headers);
            await authPolicies.Apply(httpRequest, ct).ConfigureAwait(false);
            return await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, ct)
                .ConfigureAwait(false);
        }, cancellationToken).ConfigureAwait(false);

        if (_statusPolicy.IsSuccess(httpResponseMessage.StatusCode))
        {
            var successResponse = await response.Map(httpResponseMessage, cancellationToken).ConfigureAwait(false);
            return ApiResult<TResponse, TError>.Success(
                successResponse,
                httpResponseMessage.StatusCode,
                httpResponseMessage.Headers);
        }

        using (httpResponseMessage)
        {
            if (_statusPolicy.IsUnauthorized(httpResponseMessage.StatusCode))
                authPolicies.InvalidateRevocable();

            var errorResponse = await errorResponseDeserializer.Map(httpResponseMessage, cancellationToken).ConfigureAwait(false);
            return ApiResult<TResponse, TError>.Failure(
                errorResponse!,
                httpResponseMessage.StatusCode,
                httpResponseMessage.Headers);
        }
    }

    public async Task<TResponse> Execute<TResponse, TError>(
        UrlTemplate urlTemplate,
        IReadOnlyCollection<TemplateParam> templateParameters,
        IReadOnlyCollection<Param> queryParameters,
        IReadOnlyCollection<HeaderParam> headerParameters,
        HttpMethod httpMethod,
        IRequest request,
        IResponse<TResponse> response,
        IErrorResponse<TError> errorResponseDeserializer,
        IReadOnlyList<IAuthScheme> authPolicies,
        CancellationToken cancellationToken) =>
        (await ExecuteResult(
            urlTemplate,
            templateParameters,
            queryParameters,
            headerParameters,
            httpMethod,
            request,
            response,
            errorResponseDeserializer,
            authPolicies,
            cancellationToken).ConfigureAwait(false)).GetResponseOrThrow();

    public async IAsyncEnumerable<TItem> ExecutePagedItems<TResponse, TState, TItem, TError>(
        TState initialState,
        Func<TState, ApiRequest> requestFactory,
        Func<TResponse, IReadOnlyList<TItem>> getItems,
        Func<TResponse, TState, TState?> getNextState,
        ApiResponse<TResponse, TError> response,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var result in ExecutePagedResults(
                           initialState,
                           requestFactory,
                           getNextState,
                           response,
                           ct).ConfigureAwait(false))
        {
            var successResponse = result.GetResponseOrThrow();
            foreach (var item in getItems(successResponse))
            {
                yield return item;
            }
        }
    }

    public async Task<ApiResult<TResponse, TError>> ExecuteResultNew<TResponse, TError>(
        ApiRequest request,
        ApiResponse<TResponse, TError> response,
        CancellationToken cancellationToken)
    {

        var uri = _uriFactory.Create(request.UrlTemplate, request.QueryParameters, request.TemplateParameters);
        var headers = _headerFactory.Create(request.HeaderParameters);

        var pipeline = _resiliencePipelineFactory.Create(request.Request);

        // Execute request with retry policy. See ExecuteResult: on success the response lifetime is owned
        // by IResponse.Map; the error path below owns disposal explicitly.
        var httpResponseMessage = await pipeline.ExecuteAsync(async ct =>
        {
            using var httpRequest = new HttpRequestMessage(request.HttpMethod, uri);
            httpRequest.Content = request.Request.Get();
            httpRequest.Headers.AddRange(headers);
            await request.AuthPolicies.Apply(httpRequest, ct).ConfigureAwait(false);
            return await _httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, ct)
                .ConfigureAwait(false);
        }, cancellationToken).ConfigureAwait(false);

        if (_statusPolicy.IsSuccess(httpResponseMessage.StatusCode))
        {
            var successResponse = await response.Response.Map(httpResponseMessage, cancellationToken).ConfigureAwait(false);
            return ApiResult<TResponse, TError>.Success(
                successResponse,
                httpResponseMessage.StatusCode,
                httpResponseMessage.Headers);
        }

        using (httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
                request.AuthPolicies.InvalidateRevocable();

            var errorResponse = await response.ErrorResponseDeserializer.Map(httpResponseMessage, cancellationToken).ConfigureAwait(false);
            return ApiResult<TResponse, TError>.Failure(
                errorResponse!,
                httpResponseMessage.StatusCode,
                httpResponseMessage.Headers);
        }
    }

    public async IAsyncEnumerable<IReadOnlyList<TItem>> ExecutePagedPages<TResponse, TState, TItem, TError>(
        TState initialState,
        Func<TState, ApiRequest> requestFactory,
        Func<TResponse, IReadOnlyList<TItem>> getItems,
        Func<TResponse, TState, TState?> getNextState,
        ApiResponse<TResponse, TError> response,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await foreach (var result in ExecutePagedResults(
                           initialState,
                           requestFactory,
                           getNextState,
                           response,
                           ct).ConfigureAwait(false))
        {
            var successResponse = result.GetResponseOrThrow();
            yield return getItems(successResponse);
        }
    }

    public async IAsyncEnumerable<ApiResult<TResponse, TError>> ExecutePagedResults<TResponse, TState, TError>(
        TState initialState,
        Func<TState, ApiRequest> requestFactory,
        Func<TResponse, TState, TState?> getNextState,
        ApiResponse<TResponse, TError> response,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var state = initialState;

        while (true)
        {
            var request = requestFactory(state);

            var result = await ExecuteResultNew(
                request,
                response,
                ct
            ).ConfigureAwait(false);

            yield return result;

            if (!result.TryGetResponse(out var successResponse))
            {
                yield break;
            }

            var next = getNextState(successResponse, state);
            if (next == null)
            {
                yield break;
            }

            state = next;
        }
    }
}
