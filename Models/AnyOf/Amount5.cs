using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// <c>amount_in_cents</c> is not required if you pass <c>amount</c>.
/// </summary>
[JsonConverter(typeof(Amount5Converter))]
public record Amount5
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<decimal> _decimalValue;

    private Amount5(Optional<string> stringValue, Optional<decimal> decimalValue)
    {
        _stringValue = stringValue;
        _decimalValue = decimalValue;
    }

    public static Amount5 String(string value) => new(Optional<string>.Some(value), default);

    public static Amount5 Decimal(decimal value) => new(default, Optional<decimal>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public static implicit operator Amount5(string value) => String(value);

    public static implicit operator Amount5(decimal value) => Decimal(value);
}

file sealed class Amount5Converter : JsonConverter<Amount5>
{
    public override Amount5 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return Amount5.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return Amount5.Decimal(decimalValue);
        }
        throw new JsonException($"JSON does not match string or decimal schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Amount5 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(Amount5)} contains no valid value to serialize.");
        }
    }
}
