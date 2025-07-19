using Spectre.Console;
using UpBank.Api;

namespace UpBank.Cli;

public static class UpConsoleExtensions
{
    public static Text GetBalanceText(this UpMoney money)
        => new Text($"${money.Value}");
}
