using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record GetOneTimeTokenRequest
{
    [JsonPropertyName("payment_profile")]
    public required GetOneTimeTokenPaymentProfile PaymentProfile { get; init; }
}
