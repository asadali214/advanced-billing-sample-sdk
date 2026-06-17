using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// The error is base if it is not directly associated with a single attribute.
/// </summary>
public record BaseStringError
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("base")]
    public IReadOnlyList<string>? Base { get; init; }
}
