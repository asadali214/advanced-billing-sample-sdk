using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AttributeError
{
    [JsonPropertyName("attribute")]
    public required IReadOnlyList<string> Attribute { get; init; }
}
