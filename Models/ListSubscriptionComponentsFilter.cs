using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListSubscriptionComponentsFilter
{
    /// <summary>
    /// Allows fetching components allocation with matching currency based on provided values. Use in query <c>filter[currencies]=EUR,USD</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currencies")]
    public IReadOnlyList<string>? Currencies { get; init; }

    /// <summary>
    /// Allows fetching components allocation with matching use_site_exchange_rate based on provided value. Use in query <c>filter[use_site_exchange_rate]=true</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("use_site_exchange_rate")]
    public bool? UseSiteExchangeRate { get; init; }
}
