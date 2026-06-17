using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ScheduledRenewalConfigurationRequest
{
    [JsonPropertyName("renewal_configuration")]
    public required ScheduledRenewalConfigurationRequestBody RenewalConfiguration { get; init; }
}
