using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateOrUpdateProductRequest
{
    [JsonPropertyName("product")]
    public required CreateOrUpdateProduct Product { get; init; }
}
