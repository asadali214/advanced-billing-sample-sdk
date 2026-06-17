using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateSubscriptionRequest
{
    [JsonPropertyName("subscription")]
    public required UpdateSubscription Subscription { get; init; }
}
