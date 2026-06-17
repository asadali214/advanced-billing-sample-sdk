using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupMembersArrayError
{
    [JsonPropertyName("members")]
    public required IReadOnlyList<string> Members { get; init; }
}
