using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateMultiInvoicePaymentRequest
{
    [JsonPropertyName("payment")]
    public required CreateMultiInvoicePayment Payment { get; init; }
}
