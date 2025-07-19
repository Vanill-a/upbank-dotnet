using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Attachment;

public class AttachmentListCommand : AsyncCommand<EmptyCommandSettings>
{
    public AttachmentListCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        EmptyCommandSettings settings)
    {
        var attachments = await _Client.CreateAttachmentQuery()
            .ExecuteReader()
            .GetAllRemainingPageData();

        AnsiConsole.WriteLine(attachments.Count());

        return 0;
    }
}
