using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// The quantity can contain up to 8 decimal places. i.e. 1.00 or 0.0012 or 0.00000065. If you submit a value with more than 8 decimal places, we will round it down to the 8th decimal place.
/// </summary>
[JsonConverter(typeof(Quantity3Converter))]
public record Quantity3
{
    private readonly Optional<decimal> _decimalValue;

    private readonly Optional<string> _stringValue;

    private Quantity3(Optional<decimal> decimalValue, Optional<string> stringValue)
    {
        _decimalValue = decimalValue;
        _stringValue = stringValue;
    }

    public static Quantity3 Decimal(decimal value) => new(Optional<decimal>.Some(value), default);

    public static Quantity3 String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator Quantity3(decimal value) => Decimal(value);

    public static implicit operator Quantity3(string value) => String(value);
}

file sealed class Quantity3Converter : JsonConverter<Quantity3>
{
    public override Quantity3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return Quantity3.Decimal(decimalValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return Quantity3.String(stringValue);
        }
        throw new JsonException($"JSON does not match decimal or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Quantity3 value, JsonSerializerOptions options)
    {
        if (value.TryGetDecimal(out var decimalValue))
        {
            JsonSerializer.Serialize(writer, decimalValue, options);
        }
        else if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(Quantity3)} contains no valid value to serialize.");
        }
    }
}
