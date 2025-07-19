using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Account;

public class AccountRootCommand : AsyncCommand<AccountRootSettings>
{
    public AccountRootCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        AccountRootSettings settings)
    {
        var account = await _Client.GetAccount(settings.AccountId);

        return 0;
    }
}
