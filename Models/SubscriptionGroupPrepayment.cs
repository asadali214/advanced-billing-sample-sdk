using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupPrepayment
{
    [JsonPropertyName("amount")]
    public required double Amount { get; init; }

    [JsonPropertyName("details")]
    public required string Details { get; init; }

    [JsonPropertyName("memo")]
    public required string Memo { get; init; }

    [JsonPropertyName("method")]
    public required SubscriptionGroupPrepaymentMethod Method { get; init; }
}
