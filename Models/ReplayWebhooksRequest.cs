using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ReplayWebhooksRequest
{
    [JsonPropertyName("ids")]
    public required IReadOnlyList<long> Ids { get; init; }
}
