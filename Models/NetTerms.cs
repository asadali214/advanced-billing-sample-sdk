using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record NetTerms
{
    [JsonPropertyName("default_net_terms")]
    public double? DefaultNetTerms { get; init; } = 0d;

    [JsonPropertyName("automatic_net_terms")]
    public double? AutomaticNetTerms { get; init; } = 0d;

    [JsonPropertyName("remittance_net_terms")]
    public double? RemittanceNetTerms { get; init; } = 0d;

    [JsonPropertyName("net_terms_on_remittance_signups_enabled")]
    public bool? NetTermsOnRemittanceSignupsEnabled { get; init; } = false;

    [JsonPropertyName("custom_net_terms_enabled")]
    public bool? CustomNetTermsEnabled { get; init; } = false;
}
