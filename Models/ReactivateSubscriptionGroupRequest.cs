using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ReactivateSubscriptionGroupRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("resume")]
    public bool? Resume { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("resume_members")]
    public bool? ResumeMembers { get; init; }
}
