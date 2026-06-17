using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EventResponse
{
    [JsonPropertyName("event")]
    public required Event Event { get; init; }
}
