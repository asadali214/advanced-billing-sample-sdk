using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record InvoiceResponse
{
    [JsonPropertyName("invoice")]
    public required Invoice Invoice { get; init; }
}
