using DSharpPlus;
using DSharpPlus.SlashCommands;
using Skye;

DiscordClient client = new DiscordClient(new DiscordConfiguration()
{
    Token = "MTA0MTg0NjU2NzU1ODIwNTU0MA.GNr9RZ.RDti_VARBHU5z1LE4mamoiaLAnIy9D5d40rF60",
    TokenType = TokenType.Bot
});

client.UseSlashCommands().RegisterCommands<SlashCommands>();

await client.ConnectAsync();
Thread.Sleep(-1);