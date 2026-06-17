using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionNoteResponse
{
    [JsonPropertyName("note")]
    public required SubscriptionNote Note { get; init; }
}
