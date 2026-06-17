using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record MultiInvoicePaymentResponse
{
    [JsonPropertyName("payment")]
    public required MultiInvoicePayment Payment { get; init; }
}
