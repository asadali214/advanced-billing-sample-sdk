using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ScheduledRenewalItemRequestBodyProduct
{
    /// <summary>
    /// Item type to add. Either Product or Component.
    /// </summary>
    [JsonPropertyName("item_type")]
    public string ItemType { get; } = "Product";

    /// <summary>
    /// Product or component identifier.
    /// </summary>
    [JsonPropertyName("item_id")]
    public required double ItemId { get; init; }

    /// <summary>
    /// Price point identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("price_point_id")]
    public double? PricePointId { get; init; }

    /// <summary>
    /// Optional quantity for the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity")]
    public double? Quantity { get; init; }

    /// <summary>
    /// Custom pricing for a product within a scheduled renewal.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public ScheduledRenewalProductPricePoint? CustomPrice { get; init; }
}
