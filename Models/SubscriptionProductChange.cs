using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionProductChange
{
    [JsonPropertyName("previous_product_id")]
    public required double PreviousProductId { get; init; }

    [JsonPropertyName("new_product_id")]
    public required double NewProductId { get; init; }
}
