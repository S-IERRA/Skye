using System.Text;
using System.Text.Json;
using Skye.Objects;

namespace Skye.Handlers;

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

public static class OpenAi
{
    public static async Task<OpenAiResponse?> GenerateResponse(string inputText)
    {
        OpenAiRequest aiRequest = new("text-davinci-002", inputText, 0.7, 100, 1, 0, 0);

        string inputJson = JsonSerializer.Serialize(aiRequest, JsonHelper.SerializerOptions);
        using StringContent content = new(inputJson, Encoding.UTF8, "application/json");
        
        string response =  await HttpHelper.SendAsync(OpenAiEndPoints.Completions, content);

        return JsonHelper.TryDeserialize<OpenAiResponse>(response, out var result) ? result : new OpenAiResponse();
    }
}