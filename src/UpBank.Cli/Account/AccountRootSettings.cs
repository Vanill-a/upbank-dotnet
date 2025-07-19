using Spectre.Console.Cli;

namespace UpBank.Cli.Account;

public class AccountRootSettings : CommandSettings
{
    [CommandArgument(0, "[ACCOUNT_ID]")]
    public string AccountId { get; set; }
}
