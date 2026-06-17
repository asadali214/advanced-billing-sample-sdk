using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateQuantityBasedComponent
{
    [JsonPropertyName("quantity_based_component")]
    public required QuantityBasedComponent QuantityBasedComponent { get; init; }
}
