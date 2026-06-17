using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record IssueServiceCreditRequest
{
    [JsonPropertyName("service_credit")]
    public required IssueServiceCredit ServiceCredit { get; init; }
}
