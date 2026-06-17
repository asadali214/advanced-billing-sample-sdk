using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionMrr
{
    [JsonPropertyName("subscription_id")]
    public required double SubscriptionId { get; init; }

    [JsonPropertyName("mrr_amount_in_cents")]
    public required long MrrAmountInCents { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("breakouts")]
    public SubscriptionMrrBreakout? Breakouts { get; init; }
}
