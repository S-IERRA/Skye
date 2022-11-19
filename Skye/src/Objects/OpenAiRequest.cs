namespace Skye.Objects;

public static class OpenAiEndPoints
{
    private const string BaseEndPoint = "https://api.openai.com/v1";
    public const string Completions = $"{BaseEndPoint}/completions";
}

public record OpenAiRequest(
    string Model,
    string Prompt,
    double Temperature,
    int MaxTokens,
    double TopP,
    double FrequencyPenalty,
    double PresencePenalty
);