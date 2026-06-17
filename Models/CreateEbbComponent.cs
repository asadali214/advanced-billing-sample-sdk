using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateEbbComponent
{
    [JsonPropertyName("event_based_component")]
    public required EbbComponent EventBasedComponent { get; init; }
}
