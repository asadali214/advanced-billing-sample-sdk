using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MaxioAdvancedBilling.Models;

public record SendInvoiceRequest
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

    /// <summary>
    /// Array of URLs to files to attach to the invoice email. Max 10 files, 10MB each.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("attachment_urls")]
    public IReadOnlyList<string>? AttachmentUrls { get; init; }
}
