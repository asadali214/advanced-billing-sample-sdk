using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ListMrrResponse
{
    [JsonPropertyName("mrr")]
    public required ListMrrResponseResult Mrr { get; init; }
}
