using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace UpBank.Api;

public static class UpClientServiceExtensions
{
    public const string UpApiUri = "https://api.up.com.au/api/v1/";

    public static IServiceCollection AddUpClient(
        this IServiceCollection services,
        string accessToken)
    {
        services.AddScoped<UpClient>();
        services.AddHttpClient<UpClient>(client =>
            client.ConfigureUpHttpClient(accessToken));

        return services;
    }

    public static HttpClient ConfigureUpHttpClient(
        this HttpClient client,
        string accessToken)
    {
        client.BaseAddress = new Uri(UpApiUri);
        client.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue("Bearer", accessToken);

        return client;
    }
}
