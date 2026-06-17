using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record MrrResponse
{
    [JsonPropertyName("mrr")]
    public required Mrr Mrr { get; init; }
}
