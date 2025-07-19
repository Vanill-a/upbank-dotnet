using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;
using UpBank.Api.Query;

namespace UpBank.Cli.Transaction;

public class TransactionListCommand : AsyncCommand<TransactionListSettings>
{
    public TransactionListCommand(UpClient client)
        => this._Client = client;

    private readonly UpClient _Client;

     public override async Task<int> ExecuteAsync(
        CommandContext context,
        TransactionListSettings settings)
    {
        var query = _Client.CreateTransactionQuery();

        if (settings.Status.HasValue)
            query.FilterStatus(settings.Status.Value);

        if (settings.Since.HasValue)
            query.FilterSince(settings.Since.Value);

        if (settings.Until.HasValue)
            query.FilterUntil(settings.Until.Value);
 
        if (!string.IsNullOrEmpty(settings.Category))
            query.FilterCategory(settings.Category);

        if (!string.IsNullOrEmpty(settings.Tag))
            query.FilterTag(settings.Tag);

        var reader = query.ExecuteReader();

        var table = new Table()
            .AddColumn("Id")
            .AddColumn("Date")
            .AddColumn("Amount", col => col.RightAligned())
            .AddColumn("Description")
            .Centered();

        await AnsiConsole.Live(table)
            .StartAsync(async ctx =>
            {
                while (!reader.EndOfQuery)
                {
                    var transactions = await reader.GetNextPageData();

                    foreach (var t in transactions)
                    {
                        table.AddRow(
                            new Text(t.Id),
                            new Text(t.Attributes.SettledAt.ToString() ?? string.Empty),
                            new Text($"${t.Attributes.Amount.Value}"),
                            new Text(t.Attributes.RawText ?? string.Empty));
                    }

                    ctx.Refresh();
                }
            });
        return 0;
    }
}
