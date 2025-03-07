using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace UpBank.Api;

public class UpJsonEnumConverter<T> : JsonConverter<T> where T : Enum
{
    static UpJsonEnumConverter()
    {
        _StringMap = GetStringMap();
        _EnumMap = GetEnumMap(_StringMap);
    }

    internal static readonly IReadOnlyDictionary<string, T> _StringMap;
    internal static readonly IReadOnlyDictionary<T, string> _EnumMap;

    public override T Read(
        ref System.Text.Json.Utf8JsonReader reader,
        Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options)
    {
        var value = reader.GetString();
        var output = _StringMap[value];

        return output;
    }

    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        T value,
        System.Text.Json.JsonSerializerOptions options)
        => writer.WriteStringValue(_EnumMap[value]);

    private static IReadOnlyDictionary<string, T> GetStringMap()
    {
        var type = typeof(T);
        var values = (T[])Enum.GetValues(type);
        var output = values.ToDictionary(
            i => GetEnumMemberValue(i),
            i => i);

        return output;
    }

    private static IReadOnlyDictionary<T, string> GetEnumMap(
        IReadOnlyDictionary<string, T> stringMap)
        => stringMap.ToDictionary(
            i => i.Value,
            i => i.Key);

    private static string GetEnumMemberValue(T value)
    {
        var output = typeof(T).GetMember(value.ToString())
            .Single()
            .GetCustomAttribute<EnumMemberAttribute>()
            ?.Value;

        if (string.IsNullOrEmpty(output))
            output = value.ToString();

        return output;
    }
}
