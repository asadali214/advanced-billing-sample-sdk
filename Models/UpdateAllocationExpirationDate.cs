using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateAllocationExpirationDate
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allocation")]
    public AllocationExpirationDate? Allocation { get; init; }
}
