using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreatePrepaymentRequest
{
    [JsonPropertyName("prepayment")]
    public required CreatePrepayment Prepayment { get; init; }
}
