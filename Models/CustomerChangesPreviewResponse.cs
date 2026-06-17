using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CustomerChangesPreviewResponse
{
    [JsonPropertyName("changes")]
    public required CustomerChange Changes { get; init; }
}
