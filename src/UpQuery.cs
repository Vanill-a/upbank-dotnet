using System.Collections.Specialized;
using System.Web;

namespace UpBank;

public class UpQuery<T> : IDisposable
{
    public UpQuery(HttpClient client, string endpoint)
    {
        this.Endpoint = endpoint;

        this._Client = client;
        this._Builder = HttpUtility.ParseQueryString(string.Empty);
    }

    private readonly HttpClient _Client;

    public string Endpoint { get; set; }
    
    private NameValueCollection _Builder { get; set; }

    public void Reset()
    {
        this._Builder = HttpUtility.ParseQueryString(string.Empty);
    }

    public UpQuery<T> Filter(string key, DateTime value)
        => Filter(key, value.ToString());

    public UpQuery<T> Filter(string key, string value)
    {
        _Builder[$"filter[{key}]"] = value;
        return this;
    }

    public UpQuery<T> WithPageSize(int pageSize)
    {
        _Builder["page[size]"] = Convert.ToString(pageSize);
        return this;
    }

    public UpQueryReader<T> ExecuteReader()
        => new UpQueryReader<T>(_Client, ExecuteQuery);

    private Task<HttpResponseMessage> ExecuteQuery(HttpClient client)
    {
        var uribuilder = new UriBuilder(Endpoint);
        var querystring = _Builder.ToString(); 

        if (!string.IsNullOrEmpty(querystring))
            uribuilder.Query = querystring;

        return client.GetAsync(uribuilder.Uri);
    }

    #region Dispose

    public void Dispose()
        => _Client.Dispose();

    #endregion
}
