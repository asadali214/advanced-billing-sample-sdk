using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CancellationRequest
{
    [JsonPropertyName("subscription")]
    public required CancellationOptions Subscription { get; init; }
}
