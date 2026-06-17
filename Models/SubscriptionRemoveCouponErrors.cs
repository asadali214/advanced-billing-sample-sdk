using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionRemoveCouponErrors
{
    [JsonPropertyName("subscription")]
    public required IReadOnlyList<string> Subscription { get; init; }
}
