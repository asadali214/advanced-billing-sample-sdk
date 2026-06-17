using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PrepaidUsage
{
    [JsonPropertyName("previous_unit_balance")]
    public required string PreviousUnitBalance { get; init; }

    [JsonPropertyName("previous_overage_unit_balance")]
    public required string PreviousOverageUnitBalance { get; init; }

    [JsonPropertyName("new_unit_balance")]
    public required double NewUnitBalance { get; init; }

    [JsonPropertyName("new_overage_unit_balance")]
    public required double NewOverageUnitBalance { get; init; }

    [JsonPropertyName("usage_quantity")]
    public required double UsageQuantity { get; init; }

    [JsonPropertyName("overage_usage_quantity")]
    public required double OverageUsageQuantity { get; init; }

    [JsonPropertyName("component_id")]
    public required double ComponentId { get; init; }

    [JsonPropertyName("component_handle")]
    public required string ComponentHandle { get; init; }

    [JsonPropertyName("memo")]
    public required string Memo { get; init; }

    [JsonPropertyName("allocation_details")]
    public required IReadOnlyList<PrepaidUsageAllocationDetail> AllocationDetails { get; init; }
}
