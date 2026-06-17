using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PrepaidUsageAllocationDetail
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allocation_id")]
    public double? AllocationId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("charge_id")]
    public double? ChargeId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("usage_quantity")]
    public double? UsageQuantity { get; init; }
}
