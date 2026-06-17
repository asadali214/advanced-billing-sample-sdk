using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record RefundInvoiceRequest
{
    [JsonPropertyName("refund")]
    public required Refund Refund { get; init; }
}
