using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// A string of the dollar amount to be refunded (eg. "10.50" =&gt; $10.50)
/// </summary>
[JsonConverter(typeof(AmountConverter))]
public record Amount
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<decimal> _decimalValue;

    private Amount(Optional<string> stringValue, Optional<decimal> decimalValue)
    {
        _stringValue = stringValue;
        _decimalValue = decimalValue;
    }

    public static Amount String(string value) => new(Optional<string>.Some(value), default);

    public static Amount Decimal(decimal value) => new(default, Optional<decimal>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDecimal(out decimal value) => _decimalValue.TryGetValue(out value);

    public static implicit operator Amount(string value) => String(value);

    public static implicit operator Amount(decimal value) => Decimal(value);
}

file sealed class AmountConverter : JsonConverter<Amount>
{
    public override Amount Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return Amount.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<decimal>(root, options, out var decimalValue))
        {
            return Amount.Decimal(decimalValue);
        }
        throw new JsonException($"JSON does not match string or decimal schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Amount value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(Amount)} contains no valid value to serialize.");
        }
    }
}
