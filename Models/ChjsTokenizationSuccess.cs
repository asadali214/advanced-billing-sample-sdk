using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ChjsTokenizationSuccess
{
    [JsonPropertyName("payment_profile")]
    public required TokenizedPaymentProfile PaymentProfile { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gateway_customer_id")]
    public double? GatewayCustomerId { get; init; }
}
