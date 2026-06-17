using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ComponentResponse
{
    [JsonPropertyName("component")]
    public required Component Component { get; init; }
}
