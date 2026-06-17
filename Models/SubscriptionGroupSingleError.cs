using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupSingleError
{
    [JsonPropertyName("subscription_group")]
    public required string SubscriptionGroup { get; init; }
}
