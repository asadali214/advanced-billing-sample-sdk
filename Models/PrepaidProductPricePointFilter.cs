using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PrepaidProductPricePointFilter
{
    /// <summary>
    /// Passed as a parameter to list methods to return only non null values.
    /// </summary>
    [JsonPropertyName("product_price_point_id")]
    public string ProductPricePointId { get; } = "not_null";
}
