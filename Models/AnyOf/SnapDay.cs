using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// A day of month that subscription will be processed on. Can be 1 up to 28 or 'end'.
/// </summary>
[JsonConverter(typeof(SnapDayConverter))]
public record SnapDay
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private SnapDay(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static SnapDay Double(double value) => new(Optional<double>.Some(value), default);

    public static SnapDay String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator SnapDay(double value) => Double(value);

    public static implicit operator SnapDay(string value) => String(value);
}

file sealed class SnapDayConverter : JsonConverter<SnapDay>
{
    public override SnapDay Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return SnapDay.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return SnapDay.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, SnapDay value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(SnapDay)} contains no valid value to serialize.");
        }
    }
}
