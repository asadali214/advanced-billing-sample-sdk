using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record OfferDiscount
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("coupon_code")]
    public string? CouponCode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("coupon_id")]
    public double? CouponId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("coupon_name")]
    public string? CouponName { get; init; }
}
