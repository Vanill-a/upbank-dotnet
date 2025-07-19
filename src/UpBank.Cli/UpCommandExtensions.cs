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
    public static void AddUpCommands(
        this IConfigurator config)
    {
        config.AddUpAccountCommands();
        config.AddUpAttachmentCommands();
        config.AddUpCategoryCommands();
        config.AddUpTagCommands();
        config.AddUpTransactionCommands();
        config.AddUpUtilityCommands();
    }

    public static void AddUpAccountCommands(
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

    public static void AddUpAttachmentCommands(
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

    public static void AddUpCategoryCommands(
        this IConfigurator config)
    {
        config.AddCommand<CategoryListCommand>("categories");
        config.AddBranch("category", branch =>
        {
            branch.AddCommand<CategoryListCommand>("list")
                .WithAlias("ls");
        });
    }

    public static void AddUpTagCommands(
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

    public static void AddUpTransactionCommands(
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

    public static void AddUpUtilityCommands(
        this IConfigurator config)
    {
        config.AddCommand<PingCommand>("ping");
    }
}
