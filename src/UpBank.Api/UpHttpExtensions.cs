using System.Text.Json;

namespace UpBank.Api;

public static class UpHttpExtensions
{
    public static async Task<HttpResponseMessage> EnsureUpSuccess(
        this Task<HttpResponseMessage> responseTask)
    {
        var response = await responseTask;
        var output = await response.EnsureUpSuccess();

        return output;
    }

    public static async Task<HttpResponseMessage> EnsureUpSuccess(
            this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return response;

        var stream = await response.Content.ReadAsStreamAsync();
        var error = await JsonSerializer.DeserializeAsync<UpErrorResponse>(stream);

        if (error is null)
            throw new InvalidOperationException("Deserialization returned null.");

        var message = string.IsNullOrEmpty(response.ReasonPhrase)
            ? $"The request failed with status {response.StatusCode}."
            : $"The request failed with status {response.StatusCode}. ({response.ReasonPhrase})";

        throw new UpApiException(message, error.Errors);
    }
}
