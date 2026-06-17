using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Errors returned on creating a refund prepayment, grouped by field, as arrays of strings.
/// </summary>
public record RefundPrepaymentAggregatedErrorsResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public RefundPrepaymentAggregatedError? Errors { get; init; }
}
