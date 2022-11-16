using System.Text;
using System.Text.Json;
using Skye.Objects;

namespace Skye.Handlers;

public class LowerCasePolicy : JsonNamingPolicy
{
    //This is fucking abysmal but go fuck your self
    public override string ConvertName(string name)
    {
        StringBuilder returnValue = new StringBuilder();

        foreach (var c in name)
        {
            //omfg
            if (c is >= 'A' and <= 'Z')
                c = Char.ToLower(c);
        }

        return returnValue.ToString();
    }
}

public static class OpenAi
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = new LowerCasePolicy()
    };
    
    public static async Task<string> GenerateResponse(string inputText)
    {
        OpenAiRequest aiRequest = new()
        {
            Model = "text-davinci-002",
            Prompt = inputText,
            Temperature = 0.7,
            Max_tokens = 100,
            Top_p = 1,
            Frequency_penalty = 0,
            Presence_penalty = 0
        };
        
        string inputJson = JsonSerializer.Serialize(aiRequest, SerializerOptions);
        Console.WriteLine(inputJson);
        using StringContent content = new StringContent(inputJson, Encoding.UTF8, "application/json");

        return await HttpHelper.SendAsync(OpenAiEndPoints.Completions, content);
    }
}