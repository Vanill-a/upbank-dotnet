using System.Collections.Specialized;
using System.Web;

namespace UpBank.Api.Query;

public class UpQuery<T>
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
        var uribuilder = new UriBuilder();
        var querystring = _Builder.ToString(); 

        uribuilder.Path = Endpoint;

        if (!string.IsNullOrEmpty(querystring))
            uribuilder.Query = querystring;

        var uri = uribuilder.Uri.PathAndQuery
            .TrimStart('/');

        return client.GetAsync(uri);
    }
}
