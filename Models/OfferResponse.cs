using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record OfferResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offer")]
    public Offer? Offer { get; init; }
}
