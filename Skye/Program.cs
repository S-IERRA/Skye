using Skye.Handlers;

string response = await OpenAi.GenerateResponse("Hi how are you?");
Console.WriteLine(response);