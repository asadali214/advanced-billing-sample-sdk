using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateMetadataRequest
{
    [JsonPropertyName("metadata")]
    public required IReadOnlyList<CreateMetadata> Metadata { get; init; }
}
