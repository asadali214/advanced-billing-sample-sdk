using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record InvoiceDiscountBreakout
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("eligible_amount")]
    public string? EligibleAmount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("discount_amount")]
    public string? DiscountAmount { get; init; }
}
