using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record CreateComponentPricePointRequest
{
    [JsonPropertyName("price_point")]
    public required PricePoint PricePoint { get; init; }
}
