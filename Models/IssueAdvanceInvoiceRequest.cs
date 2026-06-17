using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record IssueAdvanceInvoiceRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("force")]
    public bool? Force { get; init; }
}
