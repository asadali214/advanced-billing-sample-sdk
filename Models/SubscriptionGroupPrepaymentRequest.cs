using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupPrepaymentRequest
{
    [JsonPropertyName("prepayment")]
    public required SubscriptionGroupPrepayment Prepayment { get; init; }
}
