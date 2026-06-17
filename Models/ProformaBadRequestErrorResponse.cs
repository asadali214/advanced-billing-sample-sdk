using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record ProformaBadRequestErrorResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public ProformaError? Errors { get; init; }
}
