using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record TokenizedPaymentProfile
{
    [JsonPropertyName("id")]
    public required double Id { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("vault_token")]
    public string? VaultToken { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gateway_handle")]
    public string? GatewayHandle { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customer_vault_token")]
    public string? CustomerVaultToken { get; init; }
}
