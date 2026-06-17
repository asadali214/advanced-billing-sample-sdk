using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record DeliverProformaInvoiceRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recipient_emails")]
    public IReadOnlyList<string>? RecipientEmails { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cc_recipient_emails")]
    public IReadOnlyList<string>? CcRecipientEmails { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("bcc_recipient_emails")]
    public IReadOnlyList<string>? BccRecipientEmails { get; init; }
}
