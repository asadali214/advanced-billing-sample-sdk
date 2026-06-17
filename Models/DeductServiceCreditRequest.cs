using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record DeductServiceCreditRequest
{
    [JsonPropertyName("deduction")]
    public required DeductServiceCredit Deduction { get; init; }
}
