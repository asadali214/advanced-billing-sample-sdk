using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListSubscriptionComponentsResponse
{
    [JsonPropertyName("subscriptions_components")]
    public required IReadOnlyList<SubscriptionComponent> SubscriptionsComponents { get; init; }
}
