using Spectre.Console.Cli;

namespace UpBank.Cli.Attachment;

public class AttachmentRootSettings : CommandSettings
{
    [CommandArgument(0, "[ATTACHMENT_ID]")]
    public string AttachmentId { get; set; }
}
