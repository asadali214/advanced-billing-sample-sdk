using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AddressChange
{
    [JsonPropertyName("before")]
    public required InvoiceAddress Before { get; init; }

    [JsonPropertyName("after")]
    public required InvoiceAddress After { get; init; }
}
