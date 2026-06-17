using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CustomerErrorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public Errors? Errors { get; init; }
}
