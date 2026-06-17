using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionPreview
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("current_billing_manifest")]
    public BillingManifest? CurrentBillingManifest { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("next_billing_manifest")]
    public BillingManifest? NextBillingManifest { get; init; }
}
