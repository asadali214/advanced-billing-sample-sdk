using MaxioAdvancedBilling.Core.Authentication.Basic;
using MaxioAdvancedBilling.Core.Configuration;
using MaxioAdvancedBilling.Servers;

namespace MaxioAdvancedBilling;

public class MaxioAdvancedBillingClientOptions
{
    public ServerEnvironment Environment { get; set; } = ServerEnvironment.Default();
    public RetryOptions Retry { get; set; } = RetryOptions.Default();
    public ServerOptions Server { get; set; } = new();
    /// <summary>
    /// The <c>username</c> is a Maxio Chargify API key. The <c>password</c> is <c>x</c>.
    /// </summary>
    public BasicAuthCredentials? BasicAuth { get; set; }
}
