using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Used to Create or Update Endpoint
/// </summary>
public record CreateOrUpdateEndpointRequest
{
    /// <summary>
    /// Used to Create or Update Endpoint
    /// </summary>
    [JsonPropertyName("endpoint")]
    public required CreateOrUpdateEndpoint Endpoint { get; init; }
}
