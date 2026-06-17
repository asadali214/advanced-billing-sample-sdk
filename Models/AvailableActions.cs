using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AvailableActions
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("send_email")]
    public SendEmail? SendEmail { get; init; }
}
