using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateOfferRequest
{
    [JsonPropertyName("offer")]
    public required CreateOffer Offer { get; init; }
}
