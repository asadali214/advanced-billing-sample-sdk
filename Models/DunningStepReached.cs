using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record DunningStepReached
{
    [JsonPropertyName("dunner")]
    public required DunnerData Dunner { get; init; }

    [JsonPropertyName("current_step")]
    public required DunningStepData CurrentStep { get; init; }

    [JsonPropertyName("next_step")]
    public required DunningStepData NextStep { get; init; }
}
