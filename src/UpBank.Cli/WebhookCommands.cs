using UpBank.Api;

namespace UpBank.Cli;

public class WebhookCommands
{
    public WebhookCommands(UpClient client)
    {
        this._Client = client;
    }

    private readonly UpClient _Client;

    public async Task List()
    {
        var query = _Client.CreateWebhookQuery();
    }
}
