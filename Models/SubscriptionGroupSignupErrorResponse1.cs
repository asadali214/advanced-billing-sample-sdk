using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupSignupErrorResponse1
{
    [JsonPropertyName("errors")]
    public required SubscriptionGroupSignupError Errors { get; init; }
}
