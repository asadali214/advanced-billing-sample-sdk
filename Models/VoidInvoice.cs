using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record VoidInvoice
{
    [JsonPropertyName("reason")]
    public required string Reason { get; init; }
}
