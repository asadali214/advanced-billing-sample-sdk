using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreatePaymentProfileRequest
{
    [JsonPropertyName("payment_profile")]
    public required CreatePaymentProfile PaymentProfile { get; init; }
}
