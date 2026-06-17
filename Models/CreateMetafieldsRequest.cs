using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record CreateMetafieldsRequest
{
    [JsonPropertyName("metafields")]
    public required Metafields Metafields { get; init; }
}
