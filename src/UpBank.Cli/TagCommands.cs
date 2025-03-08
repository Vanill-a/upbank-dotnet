using UpBank.Api;

namespace UpBank.Cli;

public class TagCommands
{
    public TagCommands(UpClient client)
    {
        this._Client = client;
    }

    private readonly UpClient _Client;

    public async Task List()
    {
        var tags = await _Client.CreateTagQuery()
            .ExecuteReader()
            .GetAllRemainingPageData();

        foreach (var t in tags)
        {
            Console.WriteLine(t.Id);
        }
    }
}
