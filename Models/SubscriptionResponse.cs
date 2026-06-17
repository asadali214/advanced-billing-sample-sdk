using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; init; }
}
