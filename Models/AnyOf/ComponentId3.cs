using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// Component handle or component id.
/// </summary>
[JsonConverter(typeof(ComponentId3Converter))]
public record ComponentId3
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<double> _doubleValue;

    private ComponentId3(Optional<string> stringValue, Optional<double> doubleValue)
    {
        _stringValue = stringValue;
        _doubleValue = doubleValue;
    }

    public static ComponentId3 String(string value) => new(Optional<string>.Some(value), default);

    public static ComponentId3 Double(double value) => new(default, Optional<double>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public static implicit operator ComponentId3(string value) => String(value);

    public static implicit operator ComponentId3(double value) => Double(value);
}

file sealed class ComponentId3Converter : JsonConverter<ComponentId3>
{
    public override ComponentId3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return ComponentId3.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return ComponentId3.Double(doubleValue);
        }
        throw new JsonException($"JSON does not match string or double schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, ComponentId3 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(ComponentId3)} contains no valid value to serialize.");
        }
    }
}
