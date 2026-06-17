using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

[JsonConverter(typeof(ComponentIdModelConverter))]
public record ComponentIdModel
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private ComponentIdModel(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static ComponentIdModel Double(double value) => new(Optional<double>.Some(value), default);

    public static ComponentIdModel String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator ComponentIdModel(double value) => Double(value);

    public static implicit operator ComponentIdModel(string value) => String(value);
}

file sealed class ComponentIdModelConverter : JsonConverter<ComponentIdModel>
{
    public override ComponentIdModel Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return ComponentIdModel.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return ComponentIdModel.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, ComponentIdModel value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(ComponentIdModel)} contains no valid value to serialize.");
        }
    }
}
