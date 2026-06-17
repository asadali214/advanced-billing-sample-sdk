using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EnableWebhooksRequest
{
    [JsonPropertyName("webhooks_enabled")]
    public required bool WebhooksEnabled { get; init; }
}
