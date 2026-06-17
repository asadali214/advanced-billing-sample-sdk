using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProductPricePointResponse
{
    [JsonPropertyName("price_point")]
    public required ProductPricePoint PricePoint { get; init; }
}
