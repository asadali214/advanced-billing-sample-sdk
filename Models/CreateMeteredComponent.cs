using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateMeteredComponent
{
    [JsonPropertyName("metered_component")]
    public required MeteredComponent MeteredComponent { get; init; }
}
