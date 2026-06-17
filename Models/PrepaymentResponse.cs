using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PrepaymentResponse
{
    [JsonPropertyName("prepayment")]
    public required Prepayment Prepayment { get; init; }
}
