using System.Text.Json;

namespace UpBank.Api.Query;

public class UpQueryReader<T>
{
    internal UpQueryReader(
        HttpClient client,
        Func<HttpClient, Task<HttpResponseMessage>> executeQuery)
    {
        this.EndOfQuery = false;

        this._Client = client;
        this._GetNextResponse = executeQuery;
    }

    public bool EndOfQuery { get; private set; }

    private readonly HttpClient _Client;
    private Func<HttpClient, Task<HttpResponseMessage>>? _GetNextResponse;

    public async Task<IEnumerable<T>> GetAllRemainingPageData(
        CancellationToken token = default)
    {
        var output = new List<T>();

        while (!EndOfQuery)
        {
            if (token.IsCancellationRequested)
                break;

            output.AddRange(await GetNextPageData());
        }

        return output;
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
