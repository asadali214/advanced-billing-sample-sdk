using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionsMrrErrorResponse
{
    [JsonPropertyName("errors")]
    public required AttributeError Errors { get; init; }
}
