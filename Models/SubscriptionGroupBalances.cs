using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SubscriptionGroupBalances
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("prepayments")]
    public AccountBalance? Prepayments { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("service_credits")]
    public AccountBalance? ServiceCredits { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("open_invoices")]
    public AccountBalance? OpenInvoices { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pending_discounts")]
    public AccountBalance? PendingDiscounts { get; init; }
}
