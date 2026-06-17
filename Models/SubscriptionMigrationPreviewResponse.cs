using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionMigrationPreviewResponse
{
    [JsonPropertyName("migration")]
    public required SubscriptionMigrationPreview Migration { get; init; }
}
