using Spectre.Console.Cli;
using UpBank.Api;

namespace UpBank.Cli.Transaction;

public class TransactionListSettings : CommandSettings
{
    [CommandOption("--status")]
    public UpTransactionStatus? Status { get; set; }

    [CommandOption("--since")]
    public DateTime? Since { get; set; }

    [CommandOption("--until")]
    public DateTime? Until { get; set; }

    [CommandOption("--category")]
    public string? Category { get; set; }

    [CommandOption("--tag")]
    public string? Tag { get; set; }
}
