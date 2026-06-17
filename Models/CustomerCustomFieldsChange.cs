using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CustomerCustomFieldsChange
{
    [JsonPropertyName("before")]
    public required IReadOnlyList<InvoiceCustomField> Before { get; init; }

    [JsonPropertyName("after")]
    public required IReadOnlyList<InvoiceCustomField> After { get; init; }
}
