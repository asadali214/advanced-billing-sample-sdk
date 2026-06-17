using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record CreateComponentPricePointsRequest
{
    [JsonPropertyName("price_points")]
    public required IReadOnlyList<PricePoint> PricePoints { get; init; }
}
