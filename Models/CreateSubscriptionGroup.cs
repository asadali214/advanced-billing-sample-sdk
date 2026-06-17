using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateSubscriptionGroup
{
    [JsonPropertyName("subscription_id")]
    public required double SubscriptionId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("member_ids")]
    public IReadOnlyList<double>? MemberIds { get; init; }
}
