using System;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AllocationExpirationDate
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expires_at")]
    public DateTimeOffset? ExpiresAt { get; init; }
}
