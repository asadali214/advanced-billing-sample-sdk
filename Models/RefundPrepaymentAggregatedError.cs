using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record RefundPrepaymentAggregatedError
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refund")]
    public PrepaymentAggregatedError? Refund { get; init; }
}
