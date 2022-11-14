using DSharpPlus.SlashCommands;

namespace Skye;

public class SlashCommands : ApplicationCommandModule
{
    [SlashCommand("ping", "go kys iskra")]
    public async Task PingCommand(InteractionContext context) => await context.CreateResponseAsync("du bist schwul");
}