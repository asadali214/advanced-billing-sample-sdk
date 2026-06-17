using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CouponResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("coupon")]
    public Coupon? Coupon { get; init; }
}
