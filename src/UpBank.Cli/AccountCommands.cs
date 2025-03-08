using System.Text;
using ConsoleAppFramework;
using UpBank.Api;
using UpBank.Api.Query;

namespace UpBank.Cli;

public class AccountCommands
{
    public AccountCommands(UpClient client)
    {
        this._Client = client;
    }

    private readonly UpClient _Client;

    [Command("")]
    public async Task Root([Argument] string accountId)
    {
        var account = await _Client.GetAccount(accountId);

        Console.WriteLine("---Up Account---");
        Console.WriteLine($"Id: {account.Id}");
        Console.WriteLine($"Name: {account.Attributes.DisplayName}");
        Console.WriteLine($"Balance: {account.Attributes.Balance.Value}");
        Console.WriteLine($"Type: {account.Attributes.AccountType}");
        Console.WriteLine($"Ownership: {account.Attributes.OwnershipType}");
    }

    public async Task List(
        UpAccountType? accountType = null,
        UpOwnershipType? ownershipType = null)
    {
        var query = _Client.CreateAccountQuery();

        if (accountType.HasValue)
            query.FilterAccountType(accountType.Value);

        if (ownershipType.HasValue)
            query.FilterOwnershipType(ownershipType.Value);

        var result = await query.ExecuteReader()
            .GetAllRemainingPageData();

        var accounts = result.OrderByDescending(i => i.Attributes.AccountType)
            .ThenByDescending(i => i.Attributes.Balance.ValueInBaseUnits)
            .ThenBy(i => i.Attributes.DisplayName);

        foreach (var a in accounts)
        {
            Console.WriteLine("{0,-20}  {1,10:C2} ({2})",
                a.Attributes.DisplayName,
                a.Attributes.Balance.Value,
                a.Id);
        }
    }
}
