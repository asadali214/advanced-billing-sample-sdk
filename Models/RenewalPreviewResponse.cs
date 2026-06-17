using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record RenewalPreviewResponse
{
    [JsonPropertyName("renewal_preview")]
    public required RenewalPreview RenewalPreview { get; init; }
}
