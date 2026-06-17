using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListSubscriptionGroupPrepayment
{
    [JsonPropertyName("prepayment")]
    public required ListSubcriptionGroupPrepaymentItem Prepayment { get; init; }
}
