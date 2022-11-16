namespace Skye.Objects;

public class OpenAiEndPoints
{
    private const string BaseEndPoint = "https://api.openai.com/v1";
    public const string Completions = $"{BaseEndPoint}/completions";
}

public record OpenAiRequest(
    string Model,
    string Prompt,
    double Temperature,
    int MaxTokens,
    int TopP,
    int FrequencyPenalty,
    int PresencePenalty
);

public class OpenAiResponse
{
    public string Id { get; set; }
    public string Object { get; set; }
    public uint Created { get; set; }
    public string Model { get; set; }
    public Choices[] Choices { get; set; }
    public Usage Usage { get; set; }
}

public class Choices
{
    public string Text { get; set; }
    public ushort Index { get; set; }
    public object LogProbs { get; set; }
    public string FinishReason { get; set; }
}

public class Usage
{
    public ushort PromptTokens { get; set; }
    public ushort CompletionTokens { get; set; }
    public ushort TotalTokens { get; set; }
}