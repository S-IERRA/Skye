using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using Skye.Handlers;

namespace Skye.Extensions;

public class SnakeCase : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        StringBuilder returnValue = new();

        for (var index = 0; index < name.Length; index++)
        {
            char currentChar = name[index];
            
            switch (currentChar)
            {
                case >= 'A' and <= 'Z':
                {
                    if (index != 0 && name[index - 1] is >= 'a' and <= 'z')
                        returnValue.Append('_');

                    returnValue.Append(Char.ToLower(currentChar));
                    continue;
                }
                default:
                    returnValue.Append(currentChar);
                    break;
            }
        }

        return returnValue.ToString();
    }
}
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