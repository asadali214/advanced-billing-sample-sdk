using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record TooManyManagementLinkRequestsError1
{
    [JsonPropertyName("errors")]
    public required TooManyManagementLinkRequests Errors { get; init; }
}
