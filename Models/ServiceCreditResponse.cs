using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ServiceCreditResponse
{
    [JsonPropertyName("service_credit")]
    public required ServiceCredit ServiceCredit { get; init; }
}
