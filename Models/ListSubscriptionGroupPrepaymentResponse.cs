using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListSubscriptionGroupPrepaymentResponse
{
    [JsonPropertyName("prepayments")]
    public required IReadOnlyList<ListSubscriptionGroupPrepayment> Prepayments { get; init; }
}
