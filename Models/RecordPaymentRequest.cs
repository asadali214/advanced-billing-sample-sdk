using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record RecordPaymentRequest
{
    [JsonPropertyName("payment")]
    public required CreatePayment Payment { get; init; }
}
