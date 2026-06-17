using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CouponCurrencyRequest
{
    [JsonPropertyName("currency_prices")]
    public required IReadOnlyList<UpdateCouponCurrency> CurrencyPrices { get; init; }
}
