using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Tag;

public class TagListCommand : AsyncCommand<EmptyCommandSettings>
{
    public TagListCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        EmptyCommandSettings settings)
    {
        var tags = await _Client.CreateTagQuery()
            .ExecuteReader()
            .GetAllRemainingPageData();

        var columns = tags.Select(i => new Text(i.Id));
        var display = new Columns(columns);

        AnsiConsole.Write(display);

        return 0;
    }
}
