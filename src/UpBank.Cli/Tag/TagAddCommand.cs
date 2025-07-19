using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Tag;

public class TagAddCommand : AsyncCommand<TagAddRemoveSettings>
{
    public TagAddCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        TagAddRemoveSettings settings)
    {
        return 0;
    }
}
