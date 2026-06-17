using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// For Quantity-based components: The current allocation for the component on the given subscription. For On/Off components: Use 1 for on. Use 0 for off.
/// </summary>
[JsonConverter(typeof(AllocatedQuantity2Converter))]
public record AllocatedQuantity2
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private AllocatedQuantity2(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static AllocatedQuantity2 Double(double value) => new(Optional<double>.Some(value), default);

    public static AllocatedQuantity2 String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator AllocatedQuantity2(double value) => Double(value);

    public static implicit operator AllocatedQuantity2(string value) => String(value);
}

file sealed class AllocatedQuantity2Converter : JsonConverter<AllocatedQuantity2>
{
    public override AllocatedQuantity2 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return AllocatedQuantity2.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return AllocatedQuantity2.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, AllocatedQuantity2 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(AllocatedQuantity2)} contains no valid value to serialize.");
        }
    }
}
