using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EnableWebhooksResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("webhooks_enabled")]
    public bool? WebhooksEnabled { get; init; }
}
