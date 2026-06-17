using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupSignupEventData
{
    [JsonPropertyName("subscription_group")]
    public required SubscriptionGroupSignupFailureData SubscriptionGroup { get; init; }

    [JsonPropertyName("customer")]
    public required Customer? Customer { get; init; }
}
