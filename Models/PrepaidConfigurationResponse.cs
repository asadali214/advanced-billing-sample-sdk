using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PrepaidConfigurationResponse
{
    [JsonPropertyName("prepaid_configuration")]
    public required PrepaidConfiguration PrepaidConfiguration { get; init; }
}
