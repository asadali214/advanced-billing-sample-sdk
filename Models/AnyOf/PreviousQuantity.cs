using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// The allocated quantity that was in effect before this allocation was created. String for components supporting fractional quantities
/// </summary>
[JsonConverter(typeof(PreviousQuantityConverter))]
public record PreviousQuantity
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private PreviousQuantity(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static PreviousQuantity Double(double value) => new(Optional<double>.Some(value), default);

    public static PreviousQuantity String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator PreviousQuantity(double value) => Double(value);

    public static implicit operator PreviousQuantity(string value) => String(value);
}

file sealed class PreviousQuantityConverter : JsonConverter<PreviousQuantity>
{
    public override PreviousQuantity Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return PreviousQuantity.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return PreviousQuantity.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, PreviousQuantity value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(PreviousQuantity)} contains no valid value to serialize.");
        }
    }
}
