using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record RefundPrepaymentBaseRefundError
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refund")]
    public BaseRefundError? Refund { get; init; }
}
