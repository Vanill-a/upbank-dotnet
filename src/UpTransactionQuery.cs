using System.Web;

namespace UpBank;

public class UpTransactionQuery : IUpQuery
{
    public int? PageSize { get; set; }
    public string? Status { get; set; }
    public DateTime? Since { get; set; }
    public DateTime? Until { get; set; }
    public string? Category { get; set; }
    public string? Tag { get; set; }

    public string? GetQueryString()
    {
        var builder = HttpUtility.ParseQueryString(string.Empty);

        if (PageSize.HasValue)
            builder["page[size]"] = Convert.ToString(PageSize);

        if (string.IsNullOrEmpty(Status))
            builder["filter[status]"] = Status;

        if (Since.HasValue)
            builder["filter[since]"] = Since.ToString();

        if (Until.HasValue)
            builder["filter[until]"] = Until.ToString();

        if (string.IsNullOrEmpty(Category))
            builder["filter[category]"] = Category;

        if (string.IsNullOrEmpty(Tag))
            builder["filter[tag]"] = Tag;

        return builder.ToString();
    }
}
