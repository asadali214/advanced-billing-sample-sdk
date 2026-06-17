using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreateCustomerRequest
{
    [JsonPropertyName("customer")]
    public required CreateCustomer Customer { get; init; }
}
