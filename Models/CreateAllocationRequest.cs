using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateAllocationRequest
{
    [JsonPropertyName("allocation")]
    public required CreateAllocation Allocation { get; init; }
}
