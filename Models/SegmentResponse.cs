using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SegmentResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("segment")]
    public Segment? Segment { get; init; }
}
