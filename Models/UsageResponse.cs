using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UsageResponse
{
    [JsonPropertyName("usage")]
    public required Usage Usage { get; init; }
}
