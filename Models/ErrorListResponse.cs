using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Error which contains list of messages.
/// </summary>
public record ErrorListResponse
{
    [JsonPropertyName("errors")]
    public required IReadOnlyList<string> Errors { get; init; }
}
