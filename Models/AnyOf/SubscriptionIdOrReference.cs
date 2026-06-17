using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

[JsonConverter(typeof(SubscriptionIdOrReferenceConverter))]
public record SubscriptionIdOrReference
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private SubscriptionIdOrReference(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static SubscriptionIdOrReference Double(double value) =>
        new(Optional<double>.Some(value), default);

    public static SubscriptionIdOrReference String(string value) =>
        new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator SubscriptionIdOrReference(double value) => Double(value);

    public static implicit operator SubscriptionIdOrReference(string value) => String(value);
}

file sealed class SubscriptionIdOrReferenceConverter : JsonConverter<SubscriptionIdOrReference>
{
    public override SubscriptionIdOrReference Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return SubscriptionIdOrReference.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return SubscriptionIdOrReference.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer,
        SubscriptionIdOrReference value,
        JsonSerializerOptions options)
    {
        if (value.TryGetDouble(out var doubleValue))
        {
            JsonSerializer.Serialize(writer, doubleValue, options);
        }
        else if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(SubscriptionIdOrReference)} contains no valid value to serialize.");
        }
    }
}
