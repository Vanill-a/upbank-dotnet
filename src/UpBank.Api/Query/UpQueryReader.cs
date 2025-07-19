using System.Text.Json;

namespace UpBank.Api.Query;

public class UpQueryReader<T>
{
    private readonly HttpClient _Client;

    internal UpQueryReader(
        HttpClient client,
        Func<HttpClient, Task<HttpResponseMessage>> executeQuery)
    {
        this.EndOfQuery = false;

        this._Client = client;
        this._GetNextResponse = executeQuery;
    }

    public bool EndOfQuery { get; private set; }

    private Func<HttpClient, Task<HttpResponseMessage>>? _GetNextResponse;

    public async IAsyncEnumerable<T> ReadPagesAsync(
        CancellationToken token = default)
    {
        while (!EndOfQuery)
        {
            if (!token.IsCancellationRequested)
                yield break;

            foreach (var item in await GetNextPageData())
                yield return item;
        }
    }

    public async Task<IEnumerable<T>> GetNextPageData()
    {
        if (EndOfQuery)
            return Array.Empty<T>();

        // request should always have value if not end-of-query
        if (_GetNextResponse is null)
            throw new InvalidOperationException("Next response delegate is null for open query.");

        var response = await _GetNextResponse(_Client);

        await response.EnsureUpSuccess();

        var stream = await response.Content.ReadAsStreamAsync();
        var page = await JsonSerializer.DeserializeAsync<UpPageResponse<T>>(stream);

        if (page is null)
            throw new InvalidOperationException("Deserialization returned null.");

        var output = page.Data;
        var nexturi = page.Links?.Next;

        EndOfQuery = string.IsNullOrEmpty(nexturi);
        _GetNextResponse = !EndOfQuery
            ? new Func<HttpClient, Task<HttpResponseMessage>>(client => client.GetAsync(nexturi))
            : null;

        return output;
    }
}
