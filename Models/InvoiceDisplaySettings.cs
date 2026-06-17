using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record InvoiceDisplaySettings
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hide_zero_subtotal_lines")]
    public bool? HideZeroSubtotalLines { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("include_discounts_on_lines")]
    public bool? IncludeDiscountsOnLines { get; init; }
}
