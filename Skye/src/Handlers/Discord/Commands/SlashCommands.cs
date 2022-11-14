using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace Skye.Handlers;

public class SlashCommands : ApplicationCommandModule
{
    [SlashCommand("ping", "go kys iskra")]
    public async Task PingCommand(InteractionContext context,
        [Option("user", "idk")] DiscordUser user) => await context.CreateResponseAsync("du bist schwul " + user.Username);
}