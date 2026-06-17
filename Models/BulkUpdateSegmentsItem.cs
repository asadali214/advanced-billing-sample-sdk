using System.Collections.Generic;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record BulkUpdateSegmentsItem
{
    /// <summary>
    /// The ID of the segment you want to update.
    /// </summary>
    [JsonPropertyName("id")]
    public required double Id { get; init; }

    /// <summary>
    /// The identifier for the pricing scheme. See <see href="https://help.chargify.com/products/product-components.html">Product Components</see> for an overview of pricing schemes.
    /// </summary>
    [JsonPropertyName("pricing_scheme")]
    public required PricingScheme PricingScheme { get; init; }

    [JsonPropertyName("prices")]
    public required IReadOnlyList<CreateOrUpdateSegmentPrice> Prices { get; init; }
}
