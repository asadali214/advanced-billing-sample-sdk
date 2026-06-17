using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionMrrBreakout
{
    [JsonPropertyName("plan_amount_in_cents")]
    public required long PlanAmountInCents { get; init; }

    [JsonPropertyName("usage_amount_in_cents")]
    public required long UsageAmountInCents { get; init; }
}
