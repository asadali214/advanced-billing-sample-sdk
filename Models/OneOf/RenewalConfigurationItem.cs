using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.OneOf;

[JsonConverter(typeof(RenewalConfigurationItemConverter))]
public record RenewalConfigurationItem
{
    private RenewalConfigurationItem()
    {
    }
}

file sealed class RenewalConfigurationItemConverter : JsonConverter<RenewalConfigurationItem>
{
    public override RenewalConfigurationItem Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (!root.TryGetProperty("item_type", out var typeProperty))
        {
            throw new JsonException("Missing required 'item_type' discriminator field");
        }
        var discriminator = typeProperty.GetString();
        return discriminator switch
        {
            _ => throw new JsonException($"JSON does not match  schemas: {root.ToString()}")
        };
    }

    public override void Write(Utf8JsonWriter writer, RenewalConfigurationItem value, JsonSerializerOptions options)
    {
        throw new JsonException($"{nameof(RenewalConfigurationItem)} contains no valid value to serialize.");
    }
}
