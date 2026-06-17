using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CancelGroupedSubscriptionsRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("charge_unbilled_usage")]
    public bool? ChargeUnbilledUsage { get; init; }
}
