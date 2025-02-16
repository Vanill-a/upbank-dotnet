using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace UpBank;

public static class UpClientServiceExtensions
{
    public static IServiceCollection AddUpClient(
        this IServiceCollection services,
        string accessToken,
        string uri = "https://api.up.com.au/api/v1")
    {
        services.AddScoped<UpClient>();
        services.AddHttpClient<UpClient>(client =>
        {
            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", accessToken);
        });

        return services;
    }
}
