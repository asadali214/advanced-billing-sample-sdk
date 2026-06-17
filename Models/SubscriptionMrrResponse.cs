using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionMrrResponse
{
    [JsonPropertyName("subscriptions_mrr")]
    public required IReadOnlyList<SubscriptionMrr> SubscriptionsMrr { get; init; }
}
