using Spectre.Console.Cli;

namespace UpBank.Cli.Category;

public class CategoryListSettings : CommandSettings
{
    [CommandOption("--parent")]
    public string Parent { get; set; }
}
