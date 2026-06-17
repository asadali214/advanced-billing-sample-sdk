using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateProductPricePointRequest
{
    [JsonPropertyName("price_point")]
    public required CreateProductPricePoint PricePoint { get; init; }
}
