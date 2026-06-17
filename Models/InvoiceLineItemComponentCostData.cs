using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record InvoiceLineItemComponentCostData
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rates")]
    public IReadOnlyList<ComponentCostData>? Rates { get; init; }
}
