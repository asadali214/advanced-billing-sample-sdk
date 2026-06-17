using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupResponse
{
    [JsonPropertyName("subscription_group")]
    public required SubscriptionGroup SubscriptionGroup { get; init; }
}
