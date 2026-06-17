using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MaxioAdvancedBilling.Core.ErrorResponse;
using MaxioAdvancedBilling.Core.Models;
using MaxioAdvancedBilling.Core.Request;
using MaxioAdvancedBilling.Core.Response;

namespace MaxioAdvancedBilling.Core.Authentication.OAuth2.Password;

internal sealed class OAuth2PasswordCredentialsStrategy : IOAuth2TokenStrategy<OAuth2PasswordCredentials>
{
    private readonly UrlTemplate _tokenUrl;
    private readonly RawClient _rawClient;

    public OAuth2PasswordCredentialsStrategy(UrlTemplate tokenUrl, RawClient rawClient)
        => (_tokenUrl, _rawClient) = (tokenUrl, rawClient);

    public Task<OAuthToken> GetToken(OAuth2PasswordCredentials credentials, CancellationToken ct)
    {
        var formParams = new List<Param>
        {
            new("grant_type", "password"),
            new("client_id", credentials.ClientId),
            new("username", credentials.Username),
            new("password", credentials.Password)
        };
        if (!string.IsNullOrEmpty(credentials.ClientSecret))
            formParams.Add(new Param("client_secret", credentials.ClientSecret));
        if (!string.IsNullOrEmpty(credentials.Scope))
            formParams.Add(new Param("scope", credentials.Scope!));

        return _rawClient.Execute(
            _tokenUrl,
            [],
            [],
            [],
            HttpMethod.Post,
            FormUrlEncodedRequest.Create(formParams),
            JsonResponse.Create<OAuthToken>(),
            RawErrorResponse.Instance,
            [],
            ct);
    }
}
