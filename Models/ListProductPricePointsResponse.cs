using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListProductPricePointsResponse
{
    [JsonPropertyName("price_points")]
    public required IReadOnlyList<ProductPricePoint> PricePoints { get; init; }
}
