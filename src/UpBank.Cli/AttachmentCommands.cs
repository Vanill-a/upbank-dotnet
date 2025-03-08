
using UpBank.Api;

namespace UpBank.Cli;

public class AttachmentCommands
{
    public AttachmentCommands(UpClient client)
    {
        this._Client = client;
    }

    private readonly UpClient _Client;

    public async Task List()
    {
        var attachments = await _Client.CreateAttachmentQuery()
            .ExecuteReader()
            .GetAllRemainingPageData();
    }
}
