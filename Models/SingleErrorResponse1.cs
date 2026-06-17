using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SingleErrorResponse1
{
    [JsonPropertyName("error")]
    public required string Error { get; init; }
}
