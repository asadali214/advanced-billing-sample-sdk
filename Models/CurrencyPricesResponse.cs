using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CurrencyPricesResponse
{
    [JsonPropertyName("currency_prices")]
    public required IReadOnlyList<CurrencyPrice> CurrencyPrices { get; init; }
}
