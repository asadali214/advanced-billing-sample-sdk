using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// The price can contain up to 8 decimal places. i.e. 1.00 or 0.0012 or 0.00000065
/// </summary>
[JsonConverter(typeof(UnitPriceConverter))]
public record UnitPrice
{
    private readonly Optional<decimal> _decimalValue;

    private readonly Optional<string> _stringValue;

    private UnitPrice(Optional<decimal> decimalValue, Optional<string> stringValue)
    {
        _decimalValue = decimalValue;
        _stringValue = stringValue;
    }

    public static UnitPrice Decimal(decimal value) => new(Optional<decimal>.Some(value), default);

    public static UnitPrice String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator UnitPrice(decimal value) => Decimal(value);

    public static implicit operator UnitPrice(string value) => String(value);
}

file sealed class UnitPriceConverter : JsonConverter<UnitPrice>
{
    public override UnitPrice Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return UnitPrice.Decimal(decimalValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return UnitPrice.String(stringValue);
        }
        throw new JsonException($"JSON does not match decimal or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, UnitPrice value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(UnitPrice)} contains no valid value to serialize.");
        }
    }
}
