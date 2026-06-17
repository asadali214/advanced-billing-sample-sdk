using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CouponCurrencyResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency_prices")]
    public IReadOnlyList<CouponCurrency>? CurrencyPrices { get; init; }
}
