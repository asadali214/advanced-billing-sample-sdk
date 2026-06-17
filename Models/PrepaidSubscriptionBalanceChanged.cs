using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record PrepaidSubscriptionBalanceChanged
{
    [JsonPropertyName("reason")]
    public required string Reason { get; init; }

    [JsonPropertyName("current_account_balance_in_cents")]
    public required long CurrentAccountBalanceInCents { get; init; }

    [JsonPropertyName("prepayment_account_balance_in_cents")]
    public required long PrepaymentAccountBalanceInCents { get; init; }

    [JsonPropertyName("current_usage_amount_in_cents")]
    public required long CurrentUsageAmountInCents { get; init; }
}
