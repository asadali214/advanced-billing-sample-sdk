using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListComponentsPricePointsResponse
{
    [JsonPropertyName("price_points")]
    public required IReadOnlyList<ComponentPricePoint> PricePoints { get; init; }
}
