using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateSubscriptionGroupRequest
{
    [JsonPropertyName("subscription_group")]
    public required UpdateSubscriptionGroup SubscriptionGroup { get; init; }
}
