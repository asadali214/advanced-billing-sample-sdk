using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record RefundPrepaymentRequest
{
    [JsonPropertyName("refund")]
    public required RefundPrepayment Refund { get; init; }
}
