using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.OneOf;

namespace MaxioAdvancedBilling.Models;

public record PaymentProfileResponse
{
    [JsonPropertyName("payment_profile")]
    public required PaymentProfile PaymentProfile { get; init; }
}
