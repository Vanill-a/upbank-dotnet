using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Tag;

public class TagRemoveCommand : AsyncCommand<TagAddRemoveSettings>
{
    public TagRemoveCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        TagAddRemoveSettings settings)
    {
        return 0;
    }
}
