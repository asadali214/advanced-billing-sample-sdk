using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AddSubscriptionToAGroup
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("group")]
    public GroupSettings? Group { get; init; }
}
