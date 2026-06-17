using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record BankAccountResponse
{
    [JsonPropertyName("payment_profile")]
    public required BankAccountPaymentProfile PaymentProfile { get; init; }
}
