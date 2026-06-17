using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PaymentCollectionMethodChanged
{
    [JsonPropertyName("previous_value")]
    public required string PreviousValue { get; init; }

    [JsonPropertyName("current_value")]
    public required string CurrentValue { get; init; }
}
