using UpBank.Api;
using UpBank.Api.Query;

namespace UpBank.Cli;

public class CategoryCommands
{
    public CategoryCommands(UpClient client)
    {
        this._Client = client;
    }

    private readonly UpClient _Client;

    public async Task List(string? parent = null)
    {
        var query = _Client.CreateCategoryQuery();

        if (!string.IsNullOrEmpty(parent))
            query.FilterParent(parent);

        var categories = await query.ExecuteReader()
            .GetAllRemainingPageData();

        foreach (var c in categories)
        {
            Console.WriteLine(c.Attributes.Name);
        }
    }
}
