using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ScheduledRenewalConfigurationResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheduled_renewal_configuration")]
    public ScheduledRenewalConfiguration? ScheduledRenewalConfiguration { get; init; }
}
