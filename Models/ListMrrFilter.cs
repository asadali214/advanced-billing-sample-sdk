using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListMrrFilter
{
    /// <summary>
    /// Submit ids in order to limit results. Use in query: <c>filter[subscription_ids]=1,2,3</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription_ids")]
    public IReadOnlyList<double>? SubscriptionIds { get; init; }
}
