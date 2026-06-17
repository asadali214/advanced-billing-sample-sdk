using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record BatchJobResponse
{
    [JsonPropertyName("batchjob")]
    public required BatchJob Batchjob { get; init; }
}
