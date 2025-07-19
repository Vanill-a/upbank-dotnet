using Spectre.Console.Cli;
using UpBank.Cli.Account;
using UpBank.Cli.Attachment;
using UpBank.Cli.Category;
using UpBank.Cli.Tag;
using UpBank.Cli.Transaction;
using UpBank.Cli.Utility;

namespace UpBank.Cli;

public static class UpCommandExtensions
{
    public static void AddAccountCommands(
        this IConfigurator config)
    {
        config.AddCommand<AccountListCommand>("accounts");
        config.AddBranch("account", branch =>
        {
            branch.AddCommand<AccountRootCommand>("");
            branch.AddCommand<AccountListCommand>("list")
                .WithAlias("ls");
        });
    }

    public static void AddAttachmentCommands(
        this IConfigurator config)
    {
        config.AddCommand<AttachmentListCommand>("attachments");
        config.AddBranch("attachment", branch =>
        {
            branch.AddCommand<AttachmentRootCommand>("");
            branch.AddCommand<AttachmentListCommand>("list")
                .WithAlias("ls");
        });
    }

    public static void AddCategoryCommands(
        this IConfigurator config)
    {
        config.AddCommand<CategoryListCommand>("categories");
        config.AddBranch("category", branch =>
        {
            branch.AddCommand<CategoryListCommand>("list")
                .WithAlias("ls");
        });
    }

    public static void AddTagCommands(
        this IConfigurator config)
    {
        config.AddCommand<TagListCommand>("tags");
        config.AddBranch("tag", branch =>
        {
            branch.AddCommand<TagListCommand>("list")
                .WithAlias("ls");

            branch.AddCommand<TagAddCommand>("add");
            branch.AddCommand<TagRemoveCommand>("rm");
        });
    }

    public static void AddTransactionCommands(
        this IConfigurator config)
    {
        config.AddCommand<TransactionListCommand>("transactions");
        config.AddBranch("transaction", branch =>
        {
            branch.AddCommand<TransactionRootCommand>("");
            branch.AddCommand<TransactionListCommand>("list")
                .WithAlias("ls");
        });
    }

    public static void AddUtilityCommands(
        this IConfigurator config)
    {
        config.AddCommand<PingCommand>("ping");
    }
}
