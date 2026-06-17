using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AllocationResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("allocation")]
    public Allocation? Allocation { get; init; }
}
