using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpsertPrepaidConfigurationRequest
{
    [JsonPropertyName("prepaid_configuration")]
    public required UpsertPrepaidConfiguration PrepaidConfiguration { get; init; }
}
