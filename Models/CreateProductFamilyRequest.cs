using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateProductFamilyRequest
{
    [JsonPropertyName("product_family")]
    public required CreateProductFamily ProductFamily { get; init; }
}
