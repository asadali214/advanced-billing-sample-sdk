using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AllocationPreviewResponse
{
    [JsonPropertyName("allocation_preview")]
    public required AllocationPreview AllocationPreview { get; init; }
}
