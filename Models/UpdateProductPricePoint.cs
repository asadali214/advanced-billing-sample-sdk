using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateProductPricePoint
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("handle")]
    public string? Handle { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_in_cents")]
    public long? PriceInCents { get; init; }
}
