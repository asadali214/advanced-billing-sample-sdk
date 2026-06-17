using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.OneOf;

namespace MaxioAdvancedBilling.Models;

public record ScheduledRenewalConfigurationItemRequest
{
    [JsonPropertyName("renewal_configuration_item")]
    public required RenewalConfigurationItem RenewalConfigurationItem { get; init; }
}
