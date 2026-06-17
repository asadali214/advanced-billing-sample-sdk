using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Updatable fields for Subscription Note
/// </summary>
public record UpdateSubscriptionNoteRequest
{
    /// <summary>
    /// Updatable fields for Subscription Note
    /// </summary>
    [JsonPropertyName("note")]
    public required UpdateSubscriptionNote Note { get; init; }
}
