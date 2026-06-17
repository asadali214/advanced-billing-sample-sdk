using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProductFamilyResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("product_family")]
    public ProductFamily? ProductFamily { get; init; }
}
