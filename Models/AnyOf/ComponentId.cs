using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// Required if passing any component to <c>components</c> attribute.
/// </summary>
[JsonConverter(typeof(ComponentIdConverter))]
public record ComponentId
{
    private readonly Optional<string> _stringValue;

    private readonly Optional<double> _doubleValue;

    private ComponentId(Optional<string> stringValue, Optional<double> doubleValue)
    {
        _stringValue = stringValue;
        _doubleValue = doubleValue;
    }

    public static ComponentId String(string value) => new(Optional<string>.Some(value), default);

    public static ComponentId Double(double value) => new(default, Optional<double>.Some(value));

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public static implicit operator ComponentId(string value) => String(value);

    public static implicit operator ComponentId(double value) => Double(value);
}

file sealed class ComponentIdConverter : JsonConverter<ComponentId>
{
    public override ComponentId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return ComponentId.String(stringValue);
        }
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return ComponentId.Double(doubleValue);
        }
        throw new JsonException($"JSON does not match string or double schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, ComponentId value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(ComponentId)} contains no valid value to serialize.");
        }
    }
}
