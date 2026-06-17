using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SiteStatistics
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_subscriptions")]
    public double? TotalSubscriptions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscriptions_today")]
    public double? SubscriptionsToday { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_revenue")]
    public string? TotalRevenue { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("revenue_today")]
    public string? RevenueToday { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("revenue_this_month")]
    public string? RevenueThisMonth { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("revenue_this_year")]
    public string? RevenueThisYear { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_canceled_subscriptions")]
    public double? TotalCanceledSubscriptions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_active_subscriptions")]
    public double? TotalActiveSubscriptions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_past_due_subscriptions")]
    public double? TotalPastDueSubscriptions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_unpaid_subscriptions")]
    public double? TotalUnpaidSubscriptions { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("total_dunning_subscriptions")]
    public double? TotalDunningSubscriptions { get; init; }
}
