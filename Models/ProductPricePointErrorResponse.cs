using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProductPricePointErrorResponse
{
    [JsonPropertyName("errors")]
    public required ProductPricePointErrors Errors { get; init; }
}
