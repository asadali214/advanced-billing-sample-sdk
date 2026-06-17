using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SingleStringErrorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public string? Errors { get; init; }
}
