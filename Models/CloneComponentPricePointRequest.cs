using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CloneComponentPricePointRequest
{
    [JsonPropertyName("price_point")]
    public required CloneComponentPricePoint PricePoint { get; init; }
}
