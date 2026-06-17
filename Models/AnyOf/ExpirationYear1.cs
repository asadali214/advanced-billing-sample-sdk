using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// (Optional when performing a Import via vault_token, required otherwise) The 4-digit credit card expiration year, as an integer or string, i.e. 2012
/// </summary>
[JsonConverter(typeof(ExpirationYear1Converter))]
public record ExpirationYear1
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private ExpirationYear1(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static ExpirationYear1 Double(double value) => new(Optional<double>.Some(value), default);

    public static ExpirationYear1 String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator ExpirationYear1(double value) => Double(value);

    public static implicit operator ExpirationYear1(string value) => String(value);
}

file sealed class ExpirationYear1Converter : JsonConverter<ExpirationYear1>
{
    public override ExpirationYear1 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return ExpirationYear1.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return ExpirationYear1.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, ExpirationYear1 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(ExpirationYear1)} contains no valid value to serialize.");
        }
    }
}
