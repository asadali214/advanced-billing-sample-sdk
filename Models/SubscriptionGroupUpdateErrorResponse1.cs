using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupUpdateErrorResponse1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public SubscriptionGroupUpdateError? Errors { get; init; }
}
