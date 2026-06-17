using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SignupProformaPreviewResponse
{
    [JsonPropertyName("proforma_invoice_preview")]
    public required SignupProformaPreview ProformaInvoicePreview { get; init; }
}
