using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListInvoicesResponse
{
    [JsonPropertyName("invoices")]
    public required IReadOnlyList<Invoice> Invoices { get; init; }
}
