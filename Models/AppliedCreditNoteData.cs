using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AppliedCreditNoteData
{
    /// <summary>
    /// The UID of the credit note
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("uid")]
    public string? Uid { get; init; }

    /// <summary>
    /// The number of the credit note
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("number")]
    public string? Number { get; init; }
}
