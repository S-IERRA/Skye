using System.Text.Json;
using Skye.Handlers;
using Skye.Objects;

OpenAiResponse? response = await OpenAi.GenerateResponse("Hi how are you?");
if (response is not { })
{
    Console.WriteLine("Invalid response");
    return;
}

foreach (var choice in response.Choices)
    Console.WriteLine(choice.Text);
