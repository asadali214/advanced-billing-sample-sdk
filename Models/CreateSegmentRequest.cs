using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateSegmentRequest
{
    [JsonPropertyName("segment")]
    public required CreateSegment Segment { get; init; }
}
