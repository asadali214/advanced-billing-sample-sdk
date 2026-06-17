using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListComponentsFilter
{
    /// <summary>
    /// Allows fetching components with matching id based on provided value. Use in query <c>filter[ids]=1,2,3</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ids")]
    public IReadOnlyList<double>? Ids { get; init; }

    /// <summary>
    /// Allows fetching components with matching use_site_exchange_rate based on provided value (refers to default price point). Use in query <c>filter[use_site_exchange_rate]=true</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("use_site_exchange_rate")]
    public bool? UseSiteExchangeRate { get; init; }
}
