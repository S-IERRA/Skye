using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Skye.Handlers;

public static class JsonHelper
{
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = new SnakeCase()
    };
    
    public static bool TryDeserialize<TClass>(string message, [NotNullWhen(true)] out TClass? result)
    {
        result = default;

        try
        {
            result = JsonSerializer.Deserialize<TClass>(message, SerializerOptions)!;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool TryDeserializeTo<TClass>(this string message, out TClass? result)
        => TryDeserialize(message, out result);
}