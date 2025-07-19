using Spectre.Console.Cli;

namespace UpBank.Cli.Transaction;

public class TransactionRootSettings : CommandSettings
{
    [CommandArgument(0, "[TRANSACTION_ID]")]
    public string TransactionId { get; set; }
}
