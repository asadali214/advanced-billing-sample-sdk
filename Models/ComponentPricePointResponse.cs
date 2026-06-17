using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ComponentPricePointResponse
{
    [JsonPropertyName("price_point")]
    public required ComponentPricePoint PricePoint { get; init; }
}
