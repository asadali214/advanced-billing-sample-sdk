using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProductPricePointErrorResponse1
{
    [JsonPropertyName("errors")]
    public required ProductPricePointErrors Errors { get; init; }
}
