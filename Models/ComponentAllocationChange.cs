using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record ComponentAllocationChange
{
    [JsonPropertyName("previous_allocation")]
    public required double PreviousAllocation { get; init; }

    [JsonPropertyName("new_allocation")]
    public required double NewAllocation { get; init; }

    [JsonPropertyName("component_id")]
    public required double ComponentId { get; init; }

    [JsonPropertyName("component_handle")]
    public required string ComponentHandle { get; init; }

    [JsonPropertyName("memo")]
    public required string Memo { get; init; }

    [JsonPropertyName("allocation_id")]
    public required double AllocationId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allocated_quantity")]
    public AllocatedQuantity? AllocatedQuantity { get; init; }
}
