using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListServiceCreditsResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("service_credits")]
    public IReadOnlyList<ServiceCredit1>? ServiceCredits { get; init; }
}
