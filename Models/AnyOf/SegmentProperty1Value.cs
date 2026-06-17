using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// A value that will occur in your events that you want to bill upon. The type of the value depends on the property type in the related event based billing metric.
/// </summary>
[JsonConverter(typeof(SegmentProperty1ValueConverter))]
public record SegmentProperty1Value
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<decimal> _decimalValue;

    private readonly Optional<double> _doubleValue;

    private readonly Optional<bool> _boolValue;

    private SegmentProperty1Value(Optional<string> stringValue,
        Optional<decimal> decimalValue,
        Optional<double> doubleValue,
        Optional<bool> boolValue)
    {
        _stringValue = stringValue;
        _decimalValue = decimalValue;
        _doubleValue = doubleValue;
        _boolValue = boolValue;
    }

    public static SegmentProperty1Value String(string value) =>
        new(Optional<string>.Some(value), default, default, default);

    public static SegmentProperty1Value Decimal(decimal value) =>
        new(default, Optional<decimal>.Some(value), default, default);

    public static SegmentProperty1Value Double(double value) =>
        new(default, default, Optional<double>.Some(value), default);

    public static SegmentProperty1Value Bool(bool value) =>
        new(default, default, default, Optional<bool>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetBool(out bool value) => _boolValue.TryGetValue(out value);

    public static implicit operator SegmentProperty1Value(string value) => String(value);

    public static implicit operator SegmentProperty1Value(decimal value) => Decimal(value);

    public static implicit operator SegmentProperty1Value(double value) => Double(value);

    public static implicit operator SegmentProperty1Value(bool value) => Bool(value);
}

file sealed class SegmentProperty1ValueConverter : JsonConverter<SegmentProperty1Value>
{
    public override SegmentProperty1Value Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return SegmentProperty1Value.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return SegmentProperty1Value.Decimal(decimalValue);
        }
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return SegmentProperty1Value.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<bool>(root, options, out var boolValue))
        {
            return SegmentProperty1Value.Bool(boolValue);
        }
        throw new JsonException($"JSON does not match string or decimal or double or bool schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, SegmentProperty1Value value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetDecimal(out var decimalValue))
        {
            JsonSerializer.Serialize(writer, decimalValue, options);
        }
        else if (value.TryGetDouble(out var doubleValue))
        {
            JsonSerializer.Serialize(writer, doubleValue, options);
        }
        else if (value.TryGetBool(out var boolValue))
        {
            JsonSerializer.Serialize(writer, boolValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(SegmentProperty1Value)} contains no valid value to serialize.");
        }
    }
}
