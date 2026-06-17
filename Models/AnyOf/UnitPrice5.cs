using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// The amount the customer will be charged per unit when the pricing scheme is “per_unit”. The price can contain up to 8 decimal places. i.e. 1.00 or 0.0012 or 0.00000065
/// </summary>
[JsonConverter(typeof(UnitPrice5Converter))]
public record UnitPrice5
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<decimal> _decimalValue;

    private UnitPrice5(Optional<string> stringValue, Optional<decimal> decimalValue)
    {
        _stringValue = stringValue;
        _decimalValue = decimalValue;
    }

    public static UnitPrice5 String(string value) => new(Optional<string>.Some(value), default);

    public static UnitPrice5 Decimal(decimal value) => new(default, Optional<decimal>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public static implicit operator UnitPrice5(string value) => String(value);

    public static implicit operator UnitPrice5(decimal value) => Decimal(value);
}

file sealed class UnitPrice5Converter : JsonConverter<UnitPrice5>
{
    public override UnitPrice5 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return UnitPrice5.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return UnitPrice5.Decimal(decimalValue);
        }
        throw new JsonException($"JSON does not match string or decimal schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, UnitPrice5 value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetDecimal(out var decimalValue))
        {
            JsonSerializer.Serialize(writer, decimalValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(UnitPrice5)} contains no valid value to serialize.");
        }
    }
}
