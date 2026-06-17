using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Updatable fields for Subscription Note
/// </summary>
public record UpdateSubscriptionNote
{
    [JsonPropertyName("body")]
    public required string Body { get; init; }

    [JsonPropertyName("sticky")]
    public required bool Sticky { get; init; }
}
