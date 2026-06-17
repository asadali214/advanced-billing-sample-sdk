using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionsMrrErrorResponse1
{
    [JsonPropertyName("errors")]
    public required AttributeError Errors { get; init; }
}
