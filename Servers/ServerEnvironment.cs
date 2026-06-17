using System;
using System.Text.Json.Serialization;
using MaxioAdvancedBilling.Core.Enum;

namespace MaxioAdvancedBilling.Servers;

[JsonConverter(typeof(StringEnumConverter<ServerEnvironment>))]
public record ServerEnvironment : StringEnum<ServerEnvironment>
{
    /// <summary>
    /// Default Advanced Billing environment hosted in US. Valid for the majority of our customers.
    /// </summary>
    public static readonly ServerEnvironment Us = new("US");
    /// <summary>
    /// Advanced Billing environment hosted in EU. Use only when you requested EU hosting for your AB account.
    /// </summary>
    public static readonly ServerEnvironment Eu = new("EU");

    private ServerEnvironment(string value) : base(value)
    {
    }

    internal T Match<T>(Func<T> onUs, Func<T> onEu) =>
        this switch
        {
            _ when this == Us => onUs(),
            _ when this == Eu => onEu(),
            _ => throw new ArgumentOutOfRangeException(nameof(ServerEnvironment),
                this,
                $"Unknown {nameof(ServerEnvironment)} value.")
        };

    public static ServerEnvironment Default() => Us;
}
