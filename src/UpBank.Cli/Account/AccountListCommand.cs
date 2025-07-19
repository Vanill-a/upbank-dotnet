using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;
using UpBank.Api.Query;

namespace UpBank.Cli.Account;

public class AccountListCommand : AsyncCommand<AccountListSettings>
{
    public AccountListCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        AccountListSettings settings)
    {
        var query = _Client.CreateAccountQuery();

        if (settings.AccountType.HasValue)
            query.FilterAccountType(settings.AccountType.Value);

        if (settings.OwnershipType.HasValue)
            query.FilterOwnershipType(settings.OwnershipType.Value);

        var result = await query.ExecuteReader()
            .GetAllRemainingPageData();

        var accounts = result.OrderByDescending(i => i.Attributes.AccountType)
            .ThenByDescending(i => i.Attributes.Balance.ValueInBaseUnits)
            .ThenBy(i => i.Attributes.DisplayName);

        var table = new Table()
            .AddColumn("Id")
            .AddColumn("Name")
            .AddColumn("Amount", col => col.RightAligned())
            .Centered();

        foreach (var a in accounts)
        {
            table.AddRow(
                new Text(a.Id),
                new Text(a.Attributes.DisplayName),
                new Text($"${a.Attributes.Balance.Value}"));
        }

        AnsiConsole.Write(table);

        return 0;
    }
}
