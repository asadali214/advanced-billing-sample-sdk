using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateSubscriptionGroupRequest
{
    [JsonPropertyName("subscription_group")]
    public required CreateSubscriptionGroup SubscriptionGroup { get; init; }
}
