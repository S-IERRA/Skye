using DSharpPlus;
using DSharpPlus.SlashCommands;

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
		Client.MessageCreated += async (sender, e) => Console.WriteLine(e.Message);
		
		await Client.ConnectAsync();
	}

	public DiscordBot() =>
		Task.Run(Create);
}