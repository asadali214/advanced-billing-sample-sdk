using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SiteResponse
{
    [JsonPropertyName("site")]
    public required Site Site { get; init; }
}
