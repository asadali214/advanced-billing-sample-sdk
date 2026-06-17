using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EventBasedBillingListSegmentsErrors1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public Errors? Errors { get; init; }
}
