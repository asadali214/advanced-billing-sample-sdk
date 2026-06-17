using System;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record AutoResume
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("automatically_resume_at")]
    public DateTimeOffset? AutomaticallyResumeAt { get; init; }
}
