using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record OkResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ok")]
    public string? Ok { get; init; }
}
