using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateCurrencyPricesRequest
{
    [JsonPropertyName("currency_prices")]
    public required IReadOnlyList<UpdateCurrencyPrice> CurrencyPrices { get; init; }
}
