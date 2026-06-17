using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EventBasedBillingListSegmentsErrors
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public Errors? Errors { get; init; }
}
