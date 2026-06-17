using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateCurrencyPricesRequest
{
    [JsonPropertyName("currency_prices")]
    public required IReadOnlyList<CreateCurrencyPrice> CurrencyPrices { get; init; }
}
