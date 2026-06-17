using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SignupProformaPreview
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("current_proforma_invoice")]
    public ProformaInvoice? CurrentProformaInvoice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("next_proforma_invoice")]
    public ProformaInvoice? NextProformaInvoice { get; init; }
}
