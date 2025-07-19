using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Account;

public class AccountListSettings : CommandSettings
{
    [CommandOption("--account-type")]
    public UpAccountType? AccountType { get; set; }

    [CommandOption("--ownership-type")]
    public UpOwnershipType? OwnershipType { get; set; }
}
