using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupSignupErrorResponse
{
    [JsonPropertyName("errors")]
    public required SubscriptionGroupSignupError Errors { get; init; }
}
