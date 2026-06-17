using System.Net.Http;

namespace MaxioAdvancedBilling.Core.Request;

internal sealed class EmptyBody : IRequest
{
    public static EmptyBody Instance { get; } = new();

    private EmptyBody() { }

    // Returns a new StringContent each time because HttpContent is disposed after
    // HttpClient.SendAsync — the singleton cannot cache a reusable instance.
    public HttpContent Get() => new StringContent(string.Empty);

    public bool CanRetry => true;
}