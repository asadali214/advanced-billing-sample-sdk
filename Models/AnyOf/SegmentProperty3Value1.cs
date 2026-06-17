using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

[JsonConverter(typeof(SegmentProperty3Value1Converter))]
public record SegmentProperty3Value1
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<decimal> _decimalValue;

    private readonly Optional<double> _doubleValue;

    private readonly Optional<bool> _boolValue;

    private SegmentProperty3Value1(Optional<string> stringValue,
        Optional<decimal> decimalValue,
        Optional<double> doubleValue,
        Optional<bool> boolValue)
    {
        _stringValue = stringValue;
        _decimalValue = decimalValue;
        _doubleValue = doubleValue;
        _boolValue = boolValue;
    }

    public static SegmentProperty3Value1 String(string value) =>
        new(Optional<string>.Some(value), default, default, default);

    public static SegmentProperty3Value1 Decimal(decimal value) =>
        new(default, Optional<decimal>.Some(value), default, default);

    public static SegmentProperty3Value1 Double(double value) =>
        new(default, default, Optional<double>.Some(value), default);

    public static SegmentProperty3Value1 Bool(bool value) =>
        new(default, default, default, Optional<bool>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetBool(out bool value) => _boolValue.TryGetValue(out value);

    public static implicit operator SegmentProperty3Value1(string value) => String(value);

    public static implicit operator SegmentProperty3Value1(decimal value) => Decimal(value);

    public static implicit operator SegmentProperty3Value1(double value) => Double(value);

    public static implicit operator SegmentProperty3Value1(bool value) => Bool(value);
}

file sealed class SegmentProperty3Value1Converter : JsonConverter<SegmentProperty3Value1>
{
    public override SegmentProperty3Value1 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return SegmentProperty3Value1.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return SegmentProperty3Value1.Decimal(decimalValue);
        }
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return SegmentProperty3Value1.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<bool>(root, options, out var boolValue))
        {
            return SegmentProperty3Value1.Bool(boolValue);
        }
        throw new JsonException($"JSON does not match string or decimal or double or bool schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, SegmentProperty3Value1 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(SegmentProperty3Value1)} contains no valid value to serialize.");
        }
    }
}
