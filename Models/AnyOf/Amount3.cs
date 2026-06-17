using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

[JsonConverter(typeof(Amount3Converter))]
public record Amount3
{
    private readonly Optional<decimal> _decimalValue;

    private readonly Optional<string> _stringValue;

    private Amount3(Optional<decimal> decimalValue, Optional<string> stringValue)
    {
        _decimalValue = decimalValue;
        _stringValue = stringValue;
    }

    public static Amount3 Decimal(decimal value) => new(Optional<decimal>.Some(value), default);

    public static Amount3 String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator Amount3(decimal value) => Decimal(value);

    public static implicit operator Amount3(string value) => String(value);
}

file sealed class Amount3Converter : JsonConverter<Amount3>
{
    public override Amount3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return Amount3.Decimal(decimalValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return Amount3.String(stringValue);
        }
        throw new JsonException($"JSON does not match decimal or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Amount3 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(Amount3)} contains no valid value to serialize.");
        }
    }
}
