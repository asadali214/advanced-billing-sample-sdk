using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreatePrepaymentResponse
{
    [JsonPropertyName("prepayment")]
    public required CreatedPrepayment Prepayment { get; init; }
}
