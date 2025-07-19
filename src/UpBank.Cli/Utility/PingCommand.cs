using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Utility;

public class PingCommand : AsyncCommand<EmptyCommandSettings>
{
    public PingCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        EmptyCommandSettings settings)
    {
        var ping = await _Client.Ping();

        AnsiConsole.WriteLine(ping.StatusEmoji);

        return 0;
    }
}
