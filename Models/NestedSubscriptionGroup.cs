using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record NestedSubscriptionGroup
{
    /// <summary>
    /// The UID for the group
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    /// <summary>
    /// Whether the group is configured to rely on a primary subscription for billing. At this time, it will always be 1.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scheme")]
    public double? Scheme { get; init; }

    /// <summary>
    /// The subscription ID of the primary within the group. Applicable to scheme 1.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("primary_subscription_id")]
    public double? PrimarySubscriptionId { get; init; }

    /// <summary>
    /// A boolean indicating whether the subscription is the primary in the group. Applicable to scheme 1.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("primary")]
    public bool? Primary { get; init; }
}
