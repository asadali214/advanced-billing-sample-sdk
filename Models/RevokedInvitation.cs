using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record RevokedInvitation
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_sent_at")]
    public string? LastSentAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_accepted_at")]
    public string? LastAcceptedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uninvited_count")]
    public double? UninvitedCount { get; init; }
}
