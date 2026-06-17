using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Models.Enums;

namespace MaxioAdvancedBilling.Models;

/// <summary>
/// Example schema for an <c>change_chargeback_status</c> event
/// </summary>
public record ChangeChargebackStatusEventData
{
    [JsonPropertyName("chargeback_status")]
    public required ChargebackStatus ChargebackStatus { get; init; }
}
