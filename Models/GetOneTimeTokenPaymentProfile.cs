using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

public record GetOneTimeTokenPaymentProfile
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public required string LastName { get; init; }

    [JsonPropertyName("masked_card_number")]
    public required string MaskedCardNumber { get; init; }

    /// <summary>
    /// The type of card used.
    /// </summary>
    [JsonPropertyName("card_type")]
    public required CardType CardType { get; init; }

    [JsonPropertyName("expiration_month")]
    public required decimal ExpirationMonth { get; init; }

    [JsonPropertyName("expiration_year")]
    public required decimal ExpirationYear { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; init; }

    /// <summary>
    /// The vault that stores the payment profile with the provided <c>vault_token</c>. Use <c>bogus</c> for testing.
    /// </summary>
    [JsonPropertyName("current_vault")]
    public required CreditCardVault CurrentVault { get; init; }

    [JsonPropertyName("vault_token")]
    public required string VaultToken { get; init; }

    [JsonPropertyName("billing_address")]
    public required string BillingAddress { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("billing_address_2")]
    public string? BillingAddress2 { get; init; }

    [JsonPropertyName("billing_city")]
    public required string BillingCity { get; init; }

    [JsonPropertyName("billing_country")]
    public required string BillingCountry { get; init; }

    [JsonPropertyName("billing_state")]
    public required string BillingState { get; init; }

    [JsonPropertyName("billing_zip")]
    public required string BillingZip { get; init; }

    [JsonPropertyName("payment_type")]
    public required string PaymentType { get; init; }

    [JsonPropertyName("disabled")]
    public required bool Disabled { get; init; }

    [JsonPropertyName("site_gateway_setting_id")]
    public required double SiteGatewaySettingId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customer_vault_token")]
    public string? CustomerVaultToken { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gateway_handle")]
    public string? GatewayHandle { get; init; }
}
