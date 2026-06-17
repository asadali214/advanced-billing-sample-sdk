using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ComponentPricePointCurrencyOverageResponse
{
    /// <summary>
    /// Extends a component price point with currency overage prices.
    /// </summary>
    [JsonPropertyName("price_point")]
    public required CurrencyOveragePrices PricePoint { get; init; }
}
