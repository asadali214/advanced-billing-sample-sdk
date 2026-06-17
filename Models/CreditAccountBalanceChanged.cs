using System;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record CreditAccountBalanceChanged
{
    [JsonPropertyName("reason")]
    public required string Reason { get; init; }

    [JsonPropertyName("service_credit_account_balance_in_cents")]
    public required long ServiceCreditAccountBalanceInCents { get; init; }

    [JsonPropertyName("service_credit_balance_change_in_cents")]
    public required long ServiceCreditBalanceChangeInCents { get; init; }

    [JsonPropertyName("currency_code")]
    public required string CurrencyCode { get; init; }

    [JsonPropertyName("at_time")]
    public required DateTimeOffset AtTime { get; init; }
}
