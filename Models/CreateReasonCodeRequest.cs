using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateReasonCodeRequest
{
    [JsonPropertyName("reason_code")]
    public required CreateReasonCode ReasonCode { get; init; }
}
