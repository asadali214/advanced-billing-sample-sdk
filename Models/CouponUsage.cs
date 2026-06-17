using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CouponUsage
{
    /// <summary>
    /// The Chargify id of the product
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public double? Id { get; init; }

    /// <summary>
    /// Name of the product
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Number of times the coupon has been applied
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("signups")]
    public double? Signups { get; init; }

    /// <summary>
    /// Dollar amount of customer savings as a result of the coupon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("savings")]
    public double? Savings { get; init; }

    /// <summary>
    /// Dollar amount of customer savings as a result of the coupon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("savings_in_cents")]
    public long? SavingsInCents { get; init; }

    /// <summary>
    /// Total revenue of the all subscriptions that have received a discount from this coupon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("revenue")]
    public double? Revenue { get; init; }

    /// <summary>
    /// Total revenue of the all subscriptions that have received a discount from this coupon.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("revenue_in_cents")]
    public long? RevenueInCents { get; init; }
}
