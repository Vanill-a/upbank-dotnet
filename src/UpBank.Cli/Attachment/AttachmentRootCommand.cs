using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Attachment;

public class AttachmentRootCommand : AsyncCommand<AttachmentRootSettings>
{
    public AttachmentRootCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        AttachmentRootSettings settings)
    {
        var attachment = await _Client.GetAttachment(settings.AttachmentId);

        return 0;
    }
}
