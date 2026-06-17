using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ReplayWebhooksResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }
}
