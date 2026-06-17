using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SingleErrorResponse
{
    [JsonPropertyName("error")]
    public required string Error { get; init; }
}
