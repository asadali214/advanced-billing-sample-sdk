using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record CreateOrUpdateSegmentPrice
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("starting_quantity")]
    public double? StartingQuantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ending_quantity")]
    public double? EndingQuantity { get; init; }

    /// <summary>
    /// The price can contain up to 8 decimal places. i.e. 1.00 or 0.0012 or 0.00000065
    /// </summary>
    [JsonPropertyName("unit_price")]
    public required UnitPrice8 UnitPrice { get; init; }
}
