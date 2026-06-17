using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Errors returned on creating a refund prepayment when bad request
/// </summary>
public record RefundPrepaymentBaseErrorsResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public RefundPrepaymentBaseRefundError? Errors { get; init; }
}
