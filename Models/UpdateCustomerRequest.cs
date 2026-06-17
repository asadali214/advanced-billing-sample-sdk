using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record UpdateCustomerRequest
{
    [JsonPropertyName("customer")]
    public required UpdateCustomer Customer { get; init; }
}
