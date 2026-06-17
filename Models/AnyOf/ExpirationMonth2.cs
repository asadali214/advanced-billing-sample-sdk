using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Extensions;
using MaxioAdvancedBilling.Core.Models;

namespace MaxioAdvancedBilling.Models.AnyOf;

/// <summary>
/// (Optional when performing a Subscription Import via vault_token, required otherwise) The 1- or 2-digit credit card expiration month, as an integer or string, i.e. 5
/// </summary>
[JsonConverter(typeof(ExpirationMonth2Converter))]
public record ExpirationMonth2
{
    private readonly Optional<double> _doubleValue;

    private readonly Optional<string> _stringValue;

    private ExpirationMonth2(Optional<double> doubleValue, Optional<string> stringValue)
    {
        _doubleValue = doubleValue;
        _stringValue = stringValue;
    }

    public static ExpirationMonth2 Double(double value) => new(Optional<double>.Some(value), default);

    public static ExpirationMonth2 String(string value) => new(default, Optional<string>.Some(value));

    public bool TryGetDouble(out double value) => _doubleValue.TryGetValue(out value);

    public bool TryGetString(out string value) => _stringValue.TryGetValue(out value);

    public static implicit operator ExpirationMonth2(double value) => Double(value);

    public static implicit operator ExpirationMonth2(string value) => String(value);
}

file sealed class ExpirationMonth2Converter : JsonConverter<ExpirationMonth2>
{
    public override ExpirationMonth2 Read(ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        if (JsonSerializer.TryDeserialize<double>(root, options, out var doubleValue))
        {
            return ExpirationMonth2.Double(doubleValue);
        }
        if (JsonSerializer.TryDeserialize<string>(root, options, out var stringValue))
        {
            return ExpirationMonth2.String(stringValue);
        }
        throw new JsonException($"JSON does not match double or string schemas: {root.ToString()}");
    }

    public override void Write(Utf8JsonWriter writer, ExpirationMonth2 value, JsonSerializerOptions options)
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
            throw new JsonException($"{nameof(ExpirationMonth2)} contains no valid value to serialize.");
        }
    }
}
