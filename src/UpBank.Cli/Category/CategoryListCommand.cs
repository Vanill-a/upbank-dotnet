using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;
using UpBank.Api.Query;

namespace UpBank.Cli.Category;

public class CategoryListCommand : AsyncCommand<CategoryListSettings>
{
    public CategoryListCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        CategoryListSettings settings)
    {
        var query = _Client.CreateCategoryQuery();

        if (!string.IsNullOrEmpty(settings.Parent))
            query.FilterParent(settings.Parent);

        var categories = await query.ExecuteReader()
            .GetAllRemainingPageData();

        var tree = new Tree("Categories");

        foreach (var c in categories)
        {
            tree.AddNode(
                new Text(c.Attributes.Name));
        }

        AnsiConsole.Write(tree);

        return 0;
    }
}
