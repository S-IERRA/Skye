namespace Skye.Objects;

public class OpenAiEndPoints
{
    private const string BaseEndPoint = "https://api.openai.com/v1";
    public const string Completions = $"{BaseEndPoint}/completions";
}

public class OpenAiRequest
{
    public string? Model { get; set; }
    public string? Prompt { get; set; }
    public double Temperature { get; set; }
    public int Max_tokens { get; set; }
    public int Top_p { get; set; }
    public int Frequency_penalty { get; set; }
    public int Presence_penalty { get; set; }
};