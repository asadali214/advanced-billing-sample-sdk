using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EventBasedBillingSegment1
{
    [JsonPropertyName("errors")]
    public required EventBasedBillingSegmentError Errors { get; init; }
}
