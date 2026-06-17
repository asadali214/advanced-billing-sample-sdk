using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record BulkCreateProductPricePointsRequest
{
    [JsonPropertyName("price_points")]
    public required IReadOnlyList<CreateProductPricePoint> PricePoints { get; init; }
}
