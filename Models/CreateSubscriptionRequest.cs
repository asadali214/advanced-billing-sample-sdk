using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateSubscriptionRequest
{
    [JsonPropertyName("subscription")]
    public required CreateSubscription Subscription { get; init; }
}
