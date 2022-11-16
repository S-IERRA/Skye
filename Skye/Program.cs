using System.Net.Http.Headers;
using System.Text.Json;
using Skye.Handlers;

//DiscordBot bot = new();

HttpClient httpClient = new()
{
    DefaultRequestHeaders = {
        Authorization = new AuthenticationHeaderValue("Bearer", "$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")
    }
};

var test = httpClient.PostAsync("https://api.openai.com/v1/completions", new StringContent(JsonSerializer.Serialize(
    new OpenAiRequest() {
        Model = "text-davinci-002",
        Input = "Tell me about your day",
        Temperature = 0.7,
        MaxTokens = 100,
        TopP = 1,
        FrequencyPenalty = 0,
        PresencePenalty = 0
    }))
);

Console.WriteLine(test.Result);
Thread.Sleep(-1);

public class OpenAiRequest
{
    public string? Model { get; set; }
    public string? Input { get; set; }
    public double Temperature { get; set; }
    public int MaxTokens { get; set; }
    public int TopP { get; set; }
    public int FrequencyPenalty { get; set; }
    public int PresencePenalty { get; set; }
};