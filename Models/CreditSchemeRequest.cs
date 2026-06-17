using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record CreditSchemeRequest
{
    [JsonPropertyName("credit_scheme")]
    public required CreditScheme CreditScheme { get; init; }
}
