using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateOnOffComponent
{
    [JsonPropertyName("on_off_component")]
    public required OnOffComponent OnOffComponent { get; init; }
}
