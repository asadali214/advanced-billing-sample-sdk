using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ComponentAllocationError
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public IReadOnlyList<ComponentAllocationErrorItem>? Errors { get; init; }
}
