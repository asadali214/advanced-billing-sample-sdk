using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MaxioAdvancedBilling.Core;
using MaxioAdvancedBilling.Core.ErrorResponse;
using MaxioAdvancedBilling.Core.Exceptions;
using MaxioAdvancedBilling.Core.Models;
using MaxioAdvancedBilling.Core.Request;
using MaxioAdvancedBilling.Core.Response;
using MaxioAdvancedBilling.Errors;
using MaxioAdvancedBilling.Models;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Api;

public sealed class SubscriptionRenewals
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal SubscriptionRenewals(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Cancel Scheduled Renewal
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="id">The renewal id.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CancelScheduledRenewalConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Cancels a scheduled renewal configuration.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> CancelScheduledRenewalConfiguration(double subscriptionId,
        double id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{id}/cancel.json"),
            [new TemplateParam("subscription_id", subscriptionId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            CancelScheduledRenewalConfigurationErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Create Scheduled Renewal
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateScheduledRenewalConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Creates a scheduled renewal configuration for a subscription. The scheduled renewal is based on the subscription’s current product and component setup.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> CreateScheduledRenewalConfiguration(double subscriptionId,
        ScheduledRenewalConfigurationRequest? body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals.json"),
            [new TemplateParam("subscription_id", subscriptionId)],
            [],
            [],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            CreateScheduledRenewalConfigurationErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Create Scheduled Renewal Configuration Item
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="scheduledRenewalsConfigurationId">The scheduled renewal configuration id.</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationItemResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="CreateScheduledRenewalConfigurationItemError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Adds product and component line items to the scheduled renewal.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationItemResponse> CreateScheduledRenewalConfigurationItem(double subscriptionId,
        double scheduledRenewalsConfigurationId,
        ScheduledRenewalConfigurationItemRequest? body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{scheduled_renewals_configuration_id}/configuration_items.json"),
            [new TemplateParam("subscription_id", subscriptionId),
                new TemplateParam("scheduled_renewals_configuration_id", scheduledRenewalsConfigurationId)],
            [],
            [],
            HttpMethod.Post,
            JsonRequest.Create(body),
            JsonResponse.Create<ScheduledRenewalConfigurationItemResponse>(),
            CreateScheduledRenewalConfigurationItemErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Delete Scheduled Renewal Configuration Item
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="scheduledRenewalsConfigurationId">The scheduled renewal configuration id.</param>
    /// <param name="id">The scheduled renewal configuration item id.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="DeleteScheduledRenewalConfigurationItemError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Removes an item from the pending renewal configuration.
    /// </remarks>
    public Task DeleteScheduledRenewalConfigurationItem(double subscriptionId,
        double scheduledRenewalsConfigurationId,
        double id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{scheduled_renewals_configuration_id}/configuration_items/{id}.json"),
            [new TemplateParam("subscription_id", subscriptionId),
                new TemplateParam("scheduled_renewals_configuration_id", scheduledRenewalsConfigurationId),
                new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Delete,
            EmptyBody.Instance,
            VoidResponse.Instance,
            DeleteScheduledRenewalConfigurationItemErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// List Scheduled Renewals
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="status">(Optional) Status filter for scheduled renewal configurations.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationsResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Lists scheduled renewal configurations for the subscription and permits an optional status query filter.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationsResponse> ListScheduledRenewalConfigurations(double subscriptionId,
        Status? status,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals.json"),
            [new TemplateParam("subscription_id", subscriptionId)],
            [new Param("status", status)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ScheduledRenewalConfigurationsResponse>(),
            RawErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Immediate Renewal Lock-In
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="id">The renewal id.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="LockInScheduledRenewalImmediatelyError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Locks in the renewal immediately.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> LockInScheduledRenewalImmediately(double subscriptionId,
        double id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{id}/immediate_lock_in.json"),
            [new TemplateParam("subscription_id", subscriptionId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            LockInScheduledRenewalImmediatelyErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Read Scheduled Renewal
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="id">The renewal id.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="RawError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Retrieves the configuration settings for the scheduled renewal.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> ReadScheduledRenewalConfiguration(double subscriptionId,
        double id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{id}.json"),
            [new TemplateParam("subscription_id", subscriptionId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            RawErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Scheduled Renewal Lock-In
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="id">The renewal id.</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="ScheduleScheduledRenewalLockInError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Schedules a future lock-in date for the renewal.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> ScheduleScheduledRenewalLockIn(double subscriptionId,
        double id,
        ScheduledRenewalLockInRequest? body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{id}/schedule_lock_in.json"),
            [new TemplateParam("subscription_id", subscriptionId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            ScheduleScheduledRenewalLockInErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Unpublish Scheduled Renewal
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="id">The renewal id.</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UnpublishScheduledRenewalConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Returns a scheduled renewal configuration to an editable state.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> UnpublishScheduledRenewalConfiguration(double subscriptionId,
        double id,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{id}/unpublish.json"),
            [new TemplateParam("subscription_id", subscriptionId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Put,
            EmptyBody.Instance,
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            UnpublishScheduledRenewalConfigurationErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Update Scheduled Renewal
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="id">The renewal id.</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateScheduledRenewalConfigurationError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates an existing configuration.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationResponse> UpdateScheduledRenewalConfiguration(double subscriptionId,
        double id,
        ScheduledRenewalConfigurationRequest? body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{id}.json"),
            [new TemplateParam("subscription_id", subscriptionId), new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<ScheduledRenewalConfigurationResponse>(),
            UpdateScheduledRenewalConfigurationErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);

    /// <summary>
    /// Update Scheduled Renewal Configuration Item
    /// </summary>
    /// <param name="subscriptionId">The Chargify id of the subscription.</param>
    /// <param name="scheduledRenewalsConfigurationId">The scheduled renewal configuration id.</param>
    /// <param name="id">The scheduled renewal configuration item id.</param>
    /// <param name="body"></param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ScheduledRenewalConfigurationItemResponse"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="UpdateScheduledRenewalConfigurationItemError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// Updates an existing configuration item’s pricing and quantity.
    /// </remarks>
    public Task<ScheduledRenewalConfigurationItemResponse> UpdateScheduledRenewalConfigurationItem(double subscriptionId,
        double scheduledRenewalsConfigurationId,
        double id,
        ScheduledRenewalUpdateRequest? body,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Production("/subscriptions/{subscription_id}/scheduled_renewals/{scheduled_renewals_configuration_id}/configuration_items/{id}.json"),
            [new TemplateParam("subscription_id", subscriptionId),
                new TemplateParam("scheduled_renewals_configuration_id", scheduledRenewalsConfigurationId),
                new TemplateParam("id", id)],
            [],
            [],
            HttpMethod.Put,
            JsonRequest.Create(body),
            JsonResponse.Create<ScheduledRenewalConfigurationItemResponse>(),
            UpdateScheduledRenewalConfigurationItemErrorResponse.Instance,
            [_auth.BasicAuth],
            ct);
}
