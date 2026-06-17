using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateInvoiceRequest
{
    [JsonPropertyName("invoice")]
    public required CreateInvoice Invoice { get; init; }
}
