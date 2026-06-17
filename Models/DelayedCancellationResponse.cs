using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record DelayedCancellationResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
