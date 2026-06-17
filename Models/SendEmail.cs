using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SendEmail
{
    [JsonPropertyName("can_execute")]
    public required bool CanExecute { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
