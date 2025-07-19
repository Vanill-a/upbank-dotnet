using Spectre.Console.Cli;

namespace UpBank.Cli.Tag;

public class TagAddRemoveSettings : CommandSettings
{
    [CommandArgument(0, "[TAG]")]
    public string Tag { get; set; }

    [CommandArgument(1, "[TRANSACTION]")]
    public string TransactionId { get; set; }
}
