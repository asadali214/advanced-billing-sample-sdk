using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record VoidInvoiceRequest
{
    [JsonPropertyName("void")]
    public required VoidInvoice Void { get; init; }
}
