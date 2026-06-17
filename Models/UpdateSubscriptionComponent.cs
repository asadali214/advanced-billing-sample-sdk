using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateSubscriptionComponent
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("component_id")]
    public double? ComponentId { get; init; }

    /// <summary>
    /// Create or update custom pricing unique to the subscription. Used in place of <c>price_point_id</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("custom_price")]
    public ComponentCustomPrice? CustomPrice { get; init; }
}
