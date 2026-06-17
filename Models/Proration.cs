using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record Proration
{
    /// <summary>
    /// The alternative to sending preserve_period as a direct attribute to migration
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("preserve_period")]
    public bool? PreservePeriod { get; init; }
}
