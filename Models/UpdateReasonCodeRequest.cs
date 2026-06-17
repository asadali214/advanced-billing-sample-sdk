using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateReasonCodeRequest
{
    [JsonPropertyName("reason_code")]
    public required UpdateReasonCode ReasonCode { get; init; }
}
