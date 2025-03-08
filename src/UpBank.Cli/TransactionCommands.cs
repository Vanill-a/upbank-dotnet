using ConsoleAppFramework;
using UpBank.Api;
using UpBank.Api.Query;

namespace UpBank.Cli;

public class TransactionCommands
{
    public TransactionCommands(UpClient client)
    {
        this._Client = client;
        this._Bleh = Console.BufferWidth;
    }

    private const string _ConsoleFmt = "{0}  {1:yyyy-MM-dd}  {2,7:C2} {3}";

    private readonly UpClient _Client;
    private readonly int _Bleh;

    [Command("")]
    public async Task Root([Argument] string transactionId)
    {
        var transaction = await _Client.GetTransaction(transactionId);
    }

    public async Task<int> List(
        [Argument] string? accountId = null,
        UpTransactionStatus? status = null,
        DateTime? since = null,
        DateTime? until = null,
        string? category = null,
        string? tag = null)
    {
        var query = _Client.CreateTransactionQuery(accountId);

        if (status.HasValue)
            query.FilterStatus(status.Value);

        if (since.HasValue)
            query.FilterSince(since.Value);

        if (until.HasValue)
            query.FilterUntil(until.Value);

        if (!string.IsNullOrEmpty(category))
            query.FilterCategory(category);

        if (!string.IsNullOrEmpty(tag))
            query.FilterTag(tag);

        var reader = query.ExecuteReader();

        while (!reader.EndOfQuery)
        {
            var transactions = await reader.GetNextPageData();

            foreach (var t in transactions)
                WriteTransaction(t);
        }

        return 0;
    }

    private void WriteTransaction(UpTransactionResource transaction)
    {
        Console.WriteLine(_ConsoleFmt,
            transaction.Id,
            transaction.Attributes.CreatedAt,
            transaction.Attributes.Amount.Value,
            transaction.Attributes.Message);
    }
}
