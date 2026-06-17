using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ScheduledRenewalConfigurationItemResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheduled_renewal_configuration_item")]
    public ScheduledRenewalConfigurationItem? ScheduledRenewalConfigurationItem { get; init; }
}
