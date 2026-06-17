using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupSignupRequest
{
    [JsonPropertyName("subscription_group")]
    public required SubscriptionGroupSignup SubscriptionGroup { get; init; }
}
