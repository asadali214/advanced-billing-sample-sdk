using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CustomerPayerChange
{
    [JsonPropertyName("before")]
    public required InvoicePayerChange Before { get; init; }

    [JsonPropertyName("after")]
    public required InvoicePayerChange After { get; init; }
}
