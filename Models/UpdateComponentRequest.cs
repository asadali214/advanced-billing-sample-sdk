using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateComponentRequest
{
    [JsonPropertyName("component")]
    public required UpdateComponent Component { get; init; }
}
