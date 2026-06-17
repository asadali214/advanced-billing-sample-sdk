using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateSegmentRequest
{
    [JsonPropertyName("segment")]
    public required UpdateSegment Segment { get; init; }
}
