using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ComponentCurrencyPricesResponse
{
    [JsonPropertyName("currency_prices")]
    public required IReadOnlyList<ComponentCurrencyPrice> CurrencyPrices { get; init; }
}
