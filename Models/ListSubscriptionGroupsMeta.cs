using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListSubscriptionGroupsMeta
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("current_page")]
    public double? CurrentPage { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_count")]
    public double? TotalCount { get; init; }
}
