using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record TooManyManagementLinkRequestsError
{
    [JsonPropertyName("errors")]
    public required TooManyManagementLinkRequests Errors { get; init; }
}
