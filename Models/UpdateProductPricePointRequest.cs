using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateProductPricePointRequest
{
    [JsonPropertyName("price_point")]
    public required UpdateProductPricePoint PricePoint { get; init; }
}
