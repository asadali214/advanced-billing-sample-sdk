using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.AnyOf;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupCreateErrorResponse
{
    [JsonPropertyName("errors")]
    public required Errors1 Errors { get; init; }
}
