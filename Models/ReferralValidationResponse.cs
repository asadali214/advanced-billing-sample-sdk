using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ReferralValidationResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("referral_code")]
    public ReferralCode? ReferralCode { get; init; }
}
