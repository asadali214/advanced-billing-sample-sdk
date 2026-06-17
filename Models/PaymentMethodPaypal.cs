using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record PaymentMethodPaypal
{
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("type")]
    public required InvoiceEventPaymentMethod Type { get; init; }
}
