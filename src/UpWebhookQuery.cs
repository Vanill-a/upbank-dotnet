using System.Web;

namespace UpBank;

public class UpWebhookQuery : IUpQuery
{
    public int? PageSize { get; set; }

    public string? GetQueryString()
    {
        var builder = HttpUtility.ParseQueryString(string.Empty);

        if (PageSize.HasValue)
            builder["page[size]"] = Convert.ToString(PageSize);

        return builder.ToString();
    }
}
