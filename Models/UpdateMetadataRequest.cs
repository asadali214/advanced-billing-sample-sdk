using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateMetadataRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public UpdateMetadata? Metadata { get; init; }
}
