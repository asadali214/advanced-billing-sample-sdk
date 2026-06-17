using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProformaError
{
    /// <summary>
    /// The error is base if it is not directly associated with a single attribute.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subscription")]
    public BaseStringError? Subscription { get; init; }
}
