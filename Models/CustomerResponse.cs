using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CustomerResponse
{
    [JsonPropertyName("customer")]
    public required Customer Customer { get; init; }
}
