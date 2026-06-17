using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record PaymentMethodApplePay
{
    [JsonPropertyName("type")]
    public required InvoiceEventPaymentMethod Type { get; init; }
}
