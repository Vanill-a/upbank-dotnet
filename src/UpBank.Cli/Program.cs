using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using UpBank.Api;
using UpBank.Cli;

var token = GetAccessToken();
var services = new ServiceCollection()
    .AddUpClient(token);

var registrar = new TypeRegistrar(services);
var app = new CommandApp(registrar);

app.Configure(builder =>
{
    builder.AddAccountCommands();
    builder.AddAttachmentCommands();
    builder.AddCategoryCommands();
    builder.AddTagCommands();
    builder.AddTransactionCommands();
    builder.AddUtilityCommands();
});

await app.RunAsync(args);

static string GetAccessToken()
{
    var output = Environment.GetEnvironmentVariable("UP_ACCESS_TOKEN");

    if (string.IsNullOrEmpty(output))
        output = "";

    return output;
}
