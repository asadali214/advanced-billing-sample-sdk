using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ErrorArrayMapResponse1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public IReadOnlyDictionary<string, object>? Errors { get; init; }
}
