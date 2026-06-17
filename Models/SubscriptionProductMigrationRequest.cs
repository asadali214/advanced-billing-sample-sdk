using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionProductMigrationRequest
{
    [JsonPropertyName("migration")]
    public required SubscriptionProductMigration Migration { get; init; }
}
