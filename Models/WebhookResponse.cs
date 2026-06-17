using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record WebhookResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("webhook")]
    public Webhook? Webhook { get; init; }
}
