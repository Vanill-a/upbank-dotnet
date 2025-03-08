using ConsoleAppFramework;
using UpBank.Api;
using UpBank.Cli;

var token = GetAccessToken();
var app = ConsoleApp.Create()
    .ConfigureServices(s =>
    {
        s.AddUpClient(token);
    });

app.Add<AccountCommands>("account");
app.Add<AttachmentCommands>("attachment");
app.Add<CategoryCommands>("category");
app.Add<TagCommands>("tag");
app.Add<TransactionCommands>("transaction");
app.Add<WebhookCommands>("webhook");

app.Add("ping", async ([FromServices] UpClient client) =>
{
    Console.WriteLine("Sending Ping...");

    try
    {
        var ping = await client.Ping();

        Console.WriteLine(ping.Id);
    }
    catch (UpApiException ex)
    {
        Console.WriteLine("Ping failed!");
        Console.WriteLine(ex.Message);
    }
});

await app.RunAsync(args);

static string GetAccessToken()
{
    return Environment.GetEnvironmentVariable("UP_ACCESS_TOKEN");
}
