using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// Either the component price point's Chargify id or its handle prefixed with <c>handle:</c>
/// </summary>
[JsonConverter(typeof(PricePointId3Converter))]
public record PricePointId3
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<double> _doubleValue;

    private PricePointId3(Optional<string> stringValue, Optional<double> doubleValue)
    {
        _stringValue = stringValue;
        _doubleValue = doubleValue;
    }

    public static PricePointId3 String(string value) => new(Optional<string>.Some(value), default);

    public static PricePointId3 Double(double value) => new(default, Optional<double>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public static implicit operator PricePointId3(string value) => String(value);

    public static implicit operator PricePointId3(double value) => Double(value);
}

file sealed class PricePointId3Converter : JsonConverter<PricePointId3>
{
    public override PricePointId3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return PricePointId3.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return PricePointId3.Double(doubleValue);
        }
        throw new JsonException($"JSON does not match string or double schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, PricePointId3 value, JsonSerializerOptions options)
    {
        if (value.TryGetString(out var stringValue))
        {
            JsonSerializer.Serialize(writer, stringValue, options);
        }
        else if (value.TryGetDouble(out var doubleValue))
        {
            JsonSerializer.Serialize(writer, doubleValue, options);
        }
        else
        {
            throw new JsonException($"{nameof(PricePointId3)} contains no valid value to serialize.");
        }
    }
}
