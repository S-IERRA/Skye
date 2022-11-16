using System.Text;
using System.Text.Json;
using Skye.Extensions;
using Skye.Objects;

namespace Skye.Handlers;

public static class OpenAi
{
    public static async Task<OpenAiResponse> GenerateResponse(string inputText)
    {
        OpenAiRequest aiRequest = new("text-babbage-001", inputText, 0.7, 100, 1, 0.5, 0);

        string inputJson = JsonSerializer.Serialize(aiRequest, JsonHelper.SerializerOptions);
        using StringContent content = new(inputJson, Encoding.UTF8, "application/json");
        
        string response =  await HttpHelper.SendAsync(OpenAiEndPoints.Completions, content);

        return JsonHelper.TryDeserialize<OpenAiResponse>(response, out var result) ? result : new OpenAiResponse();
    }
}