using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CustomerError
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customer")]
    public string? Customer { get; init; }
}
