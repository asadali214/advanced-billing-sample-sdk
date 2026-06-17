using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record EndpointResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("endpoint")]
    public Endpoint? Endpoint { get; init; }
}
