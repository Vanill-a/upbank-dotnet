using System.Net.Http.Json;
using System.Text.Json;

namespace UpBank;

public class UpClient : IDisposable
{
    public UpClient(HttpClient client)
    {
        this._Client = client;
    }

    private readonly HttpClient _Client;

    #region Accounts

    public async Task<UpAccountResource> GetAccount(string accountId)
        => await GetResource<UpAccountResource>($"/accounts/{accountId}");

    public async Task<IEnumerable<UpAccountResource>>GetAccounts(
        UpAccountQuery query)
        => await GetResources<UpAccountResource>("/accounts", query);

    #endregion;

    #region Attachments

    public async Task<UpAttachmentResource> GetAttachment(string attachmentId)
        => await GetResource<UpAttachmentResource>($"/attachments/{attachmentId}");

    public async Task<IEnumerable<UpAttachmentResource>> GetAttachments()
        => await GetResources<UpAttachmentResource>("/attachments");

    #endregion;

    #region Categories;

    public async Task<UpCategoryResource> GetCategory(string categoryId)
        => await GetResource<UpCategoryResource>($"/categories/{categoryId}");

    public async Task<IEnumerable<UpCategoryResource>> GetCategories(UpCategoryQuery query)
        => await GetResources<UpCategoryResource>("/categories", query);

    public async Task CategorizeTransaction(string transactionId, string? categoryId = null)
    {
        var uri = $"/transactions/{transactionId}/relationships/category";
        var input = !string.IsNullOrEmpty(categoryId)
            ? new UpRelationshipData("categories", categoryId)
            : null;

        var content = JsonContent.Create(input);
        var response = await _Client.PatchAsync(uri, content);

        await EnsureSuccess(response);
    }

    #endregion;

    #region Tags

    public async Task<IEnumerable<UpTagResource>> GetTags(UpTagQuery query)
        => await GetResources<UpTagResource>("/tags", query);

    public async Task AddTagsToTransaction(string transactionId, IEnumerable<string> tagIds)
        => await ModifyTransactionTags(transactionId, tagIds, HttpMethod.Post);

    public async Task RemoveTagsFromTransaction(string transactionId, IEnumerable<string> tagIds)
        => await ModifyTransactionTags(transactionId, tagIds, HttpMethod.Delete);

    private async Task ModifyTransactionTags(string transactionId, IEnumerable<string> tagIds, HttpMethod method)
    {
        var uri = $"/transactions/{transactionId}/relationships/tags";
        var tags = tagIds.Select(id => new UpRelationshipData("tags", id));
        var content = JsonContent.Create(tags);
        var message = new HttpRequestMessage
        {
            RequestUri = new Uri(uri),
            Content = content,
            Method = method,
        };

        var response = await _Client.SendAsync(message);

        await EnsureSuccess(response);
    }

    #endregion;

    #region Transactions

    public async Task<UpTransactionResource> GetTransaction(string transactionId)
        => await GetResource<UpTransactionResource>($"/transactions{transactionId}");

    public async Task<IEnumerable<UpTransactionResource>> GetTransactions(UpTransactionQuery query)
        => await GetResources<UpTransactionResource>("/transactions", query);

    public async Task<IEnumerable<UpTransactionResource>> GetAccountTransactions(string accountId,
        UpTransactionQuery? query = null)
    {
        return await GetResources<UpTransactionResource>(
            endpoint: $"/accounts/{accountId}/transactions",
            query: query);
    }

    #endregion

    #region Utility

    public async Task<UpPingResponse> Ping()
    {
        var response = await _Client.GetAsync("/util/ping");
        
        await EnsureSuccess(response);

        var json = await response.Content.ReadAsStringAsync();
        var output = JsonSerializer.Deserialize<UpPingResponse>(json);

        if (output is null)
            throw new InvalidOperationException("Deserialization returned null.");

        return output;
    }

    #endregion

    #region Webhooks

    public async Task<UpWebhookResource> GetWebhook(string webhookId)
        => await GetResource<UpWebhookResource>($"/webhooks/{webhookId}");

    public async Task<IEnumerable<UpWebhookResource>> GetWebhooks(UpWebhookQuery? query)
        => await GetResources<UpWebhookResource>("/webhooks", query);

    public async Task<UpWebhookResource> CreateWebhook()
        => throw new NotImplementedException();

    public async Task DeleteWebhook(string webhookId)
    {
        var uri = $"/webhooks/{webhookId}";
        var response = await _Client.DeleteAsync(uri);

        await EnsureSuccess(response);
    }

    public async Task<UpWebhookEventResource> PingWebhook(string webhookId)
    {
        var uri = $"/webhooks/{webhookId}/ping";
        var response = await _Client.PostAsync(uri, null);

        await EnsureSuccess(response);

        var json = await response.Content.ReadAsStringAsync();
        var output = JsonSerializer.Deserialize<UpWebhookEventResource>(json);

        if (output is null)
            throw new InvalidOperationException("Deserialization returned null.");

        return output;
    }

    public async Task<IEnumerable<UpWebhookDeliveryLogResource>> GetWebhookLogs(string webhookId,
        UpWebhookQuery? query)
    {
        return await GetResources<UpWebhookDeliveryLogResource>(
            endpoint: $"/webhooks/{webhookId}/logs",
            query: query);
    }

    #endregion

    public async Task<T> GetResource<T>(string endpoint) where T : class
    {
        var response = await _Client.GetAsync(endpoint);

        await EnsureSuccess(response);

        var stream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<UpResponse<T>>(stream);

        if (data is null)
            throw new InvalidOperationException("Deserialization returned null.");

        return data.Data;
    }

    public async Task<IEnumerable<T>> GetResources<T>(string endpoint,
        IUpQuery? query = null)
        where T : class
    {
        var uribuilder = new UriBuilder(endpoint);
        var querystring = 
            query is not null
            ? query.GetQueryString()
            : string.Empty;

        if (!string.IsNullOrEmpty(querystring))
            uribuilder.Query = querystring;

        var uri = uribuilder.ToString();
        var output = new List<T>();

        while (!string.IsNullOrEmpty(uri))
        {
            var response = await _Client.GetAsync(uri);

            await EnsureSuccess(response);

            var stream = await response.Content.ReadAsStreamAsync();
            var page = await JsonSerializer.DeserializeAsync<UpPageResponse<T>>(stream);

            if (page is null)
                throw new InvalidOperationException("Deserialization returned null.");

            output.AddRange(page.Data);
            uri = page.Links.Next;
        }

        return output;
    }

    private async Task EnsureSuccess(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var stream = await response.Content.ReadAsStreamAsync();
        var error = await JsonSerializer.DeserializeAsync<UpErrorResponse>(stream);

        if (error is null)
            throw new InvalidOperationException("Deserialization returned null.");

        var message = string.IsNullOrEmpty(response.ReasonPhrase)
            ? $"The request failed with status {response.StatusCode}."
            : $"The request failed with status {response.StatusCode}. ({response.ReasonPhrase})";

        throw new UpApiException(message, error.Errors);
    }

    public void Dispose()
        => this._Client.Dispose();
}
