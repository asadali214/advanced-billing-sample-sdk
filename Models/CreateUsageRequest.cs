using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateUsageRequest
{
    [JsonPropertyName("usage")]
    public required CreateUsage Usage { get; init; }
}
