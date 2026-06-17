using System;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ResentInvitation
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_sent_at")]
    public string? LastSentAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_accepted_at")]
    public string? LastAcceptedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("send_invite_link_text")]
    public string? SendInviteLinkText { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uninvited_count")]
    public double? UninvitedCount { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_invite_sent_at")]
    public DateTimeOffset? LastInviteSentAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("last_invite_accepted_at")]
    public DateTimeOffset? LastInviteAcceptedAt { get; init; }
}
