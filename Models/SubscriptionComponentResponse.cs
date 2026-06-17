using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionComponentResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("component")]
    public SubscriptionComponent? Component { get; init; }
}
