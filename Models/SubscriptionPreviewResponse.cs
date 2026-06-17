using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionPreviewResponse
{
    [JsonPropertyName("subscription_preview")]
    public required SubscriptionPreview SubscriptionPreview { get; init; }
}
