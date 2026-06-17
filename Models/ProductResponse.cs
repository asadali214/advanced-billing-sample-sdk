using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProductResponse
{
    [JsonPropertyName("product")]
    public required Product Product { get; init; }
}
