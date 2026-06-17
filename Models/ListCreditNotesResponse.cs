using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListCreditNotesResponse
{
    [JsonPropertyName("credit_notes")]
    public required IReadOnlyList<CreditNote> CreditNotes { get; init; }
}
