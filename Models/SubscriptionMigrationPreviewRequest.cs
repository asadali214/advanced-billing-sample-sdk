using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionMigrationPreviewRequest
{
    [JsonPropertyName("migration")]
    public required SubscriptionMigrationPreviewOptions Migration { get; init; }
}
