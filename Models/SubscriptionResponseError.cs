using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionResponseError
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; init; }
}
