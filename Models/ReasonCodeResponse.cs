using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ReasonCodeResponse
{
    [JsonPropertyName("reason_code")]
    public required ReasonCode ReasonCode { get; init; }
}
