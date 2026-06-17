using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// The allocated quantity set in to effect by the allocation. String for components supporting fractional quantities
/// </summary>
[JsonConverter(typeof(QuantityConverter))]
public record Quantity
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private Quantity(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static Quantity Double(double value) => new(Optional<double>.Some(value), default);

    public static Quantity String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator Quantity(double value) => Double(value);

    public static implicit operator Quantity(string value) => String(value);
}

file sealed class QuantityConverter : JsonConverter<Quantity>
{
    public override Quantity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return Quantity.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return Quantity.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, Quantity value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(Quantity)} contains no valid value to serialize.");
        }
    }
}
