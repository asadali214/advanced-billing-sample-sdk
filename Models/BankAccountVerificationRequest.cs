using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record BankAccountVerificationRequest
{
    [JsonPropertyName("bank_account_verification")]
    public required BankAccountVerification BankAccountVerification { get; init; }
}
