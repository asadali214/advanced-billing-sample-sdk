using System;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record Prepayment
{
    [JsonPropertyName("id")]
    public required double Id { get; init; }

    [JsonPropertyName("subscription_id")]
    public required double SubscriptionId { get; init; }

    [JsonPropertyName("amount_in_cents")]
    public required long AmountInCents { get; init; }

    [JsonPropertyName("remaining_amount_in_cents")]
    public required long RemainingAmountInCents { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refunded_amount_in_cents")]
    public long? RefundedAmountInCents { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("details")]
    public string? Details { get; init; }

    [JsonPropertyName("external")]
    public required bool External { get; init; }

    [JsonPropertyName("memo")]
    public required string Memo { get; init; }

    /// <summary>
    /// The payment type of the prepayment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payment_type")]
    public PrepaymentMethod? PaymentType { get; init; }

    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }
}
