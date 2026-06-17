using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreatePrepaidComponent
{
    [JsonPropertyName("prepaid_usage_component")]
    public required PrepaidUsageComponent PrepaidUsageComponent { get; init; }
}
