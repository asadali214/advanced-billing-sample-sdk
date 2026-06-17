using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdatePaymentProfileRequest
{
    [JsonPropertyName("payment_profile")]
    public required UpdatePaymentProfile PaymentProfile { get; init; }
}
