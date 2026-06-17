using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EbbEvent
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("chargify")]
    public ChargifyEbb? Chargify { get; init; }
}
