using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Transaction;

public class TransactionRootCommand : AsyncCommand<TransactionRootSettings>
{
    public TransactionRootCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        TransactionRootSettings settings)
    {
        var transaction = await _Client.GetTransaction(settings.TransactionId);
        return 0;
    }
}
