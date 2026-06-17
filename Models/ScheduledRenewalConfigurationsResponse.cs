using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ScheduledRenewalConfigurationsResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheduled_renewal_configurations")]
    public IReadOnlyList<ScheduledRenewalConfiguration>? ScheduledRenewalConfigurations { get; init; }
}
