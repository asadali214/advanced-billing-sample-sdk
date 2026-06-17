using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateCurrencyPrice
{
    /// <summary>
    /// ID of the currency price record being updated
    /// </summary>
    [JsonPropertyName("id")]
    public required double Id { get; init; }

    /// <summary>
    /// New price for the given currency
    /// </summary>
    [JsonPropertyName("price")]
    public required decimal Price { get; init; }
}
