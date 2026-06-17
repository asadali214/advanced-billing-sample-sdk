using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateCouponCurrency
{
    /// <summary>
    /// ISO code for the site defined currency.
    /// </summary>
    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    /// <summary>
    /// Price for the given currency.
    /// </summary>
    [JsonPropertyName("price")]
    public required double Price { get; init; }
}
