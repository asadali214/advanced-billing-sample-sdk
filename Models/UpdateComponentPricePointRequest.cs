using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateComponentPricePointRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_point")]
    public UpdateComponentPricePoint? PricePoint { get; init; }
}
