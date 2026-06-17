using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CloneComponentPricePoint
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("handle")]
    public string? Handle { get; init; }
}
