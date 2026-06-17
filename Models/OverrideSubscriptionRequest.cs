using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record OverrideSubscriptionRequest
{
    [JsonPropertyName("subscription")]
    public required OverrideSubscription Subscription { get; init; }
}
