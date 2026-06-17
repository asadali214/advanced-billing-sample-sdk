using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateCurrencyPrice
{
    /// <summary>
    /// ISO code for a currency defined on the site level
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    /// <summary>
    /// Price for the price level in this currency
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    /// <summary>
    /// ID of the price that this corresponds with
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_id")]
    public double? PriceId { get; init; }
}
