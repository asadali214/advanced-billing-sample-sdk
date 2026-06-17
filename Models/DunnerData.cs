using System;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record DunnerData
{
    [JsonPropertyName("state")]
    public required string State { get; init; }

    [JsonPropertyName("subscription_id")]
    public required double SubscriptionId { get; init; }

    [JsonPropertyName("revenue_at_risk_in_cents")]
    public required long RevenueAtRiskInCents { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("attempts")]
    public required double Attempts { get; init; }

    [JsonPropertyName("last_attempted_at")]
    public required DateTimeOffset LastAttemptedAt { get; init; }
}
