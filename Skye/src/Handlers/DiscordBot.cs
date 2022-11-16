using DSharpPlus;
using DSharpPlus.SlashCommands;
using Skye.Objects;

namespace Skye.Handlers;

public class DiscordBot
{
	private static readonly DiscordConfiguration Configuration = new()
	{
		Token = "MTA0MTg0NjU2NzU1ODIwNTU0MA.GNr9RZ.RDti_VARBHU5z1LE4mamoiaLAnIy9D5d40rF60",
		TokenType = TokenType.Bot,
		Intents = DiscordIntents.All
	};

	private static readonly DiscordClient Client = new(Configuration);

	private static async Task Create()
	{
		Client.MessageCreated += async (sender, e) =>
		{
			if (e.Author.IsCurrent)
				return;
			
			OpenAiResponse response = await OpenAi.GenerateResponse(e.Message.Content);

			foreach (var choice in response.Choices)
				await e.Message.RespondAsync(choice.Text);
		};
		
		await Client.ConnectAsync();
	}

	public DiscordBot() =>
		Task.Run(Create);
}