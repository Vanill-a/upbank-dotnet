using System.Text.Json.Serialization;
using System.Web;

namespace UpBank;

public class UpCategoryQuery : IUpQuery
{
    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    public string? GetQueryString()
    {
        var builder = HttpUtility.ParseQueryString(string.Empty);

        if (!string.IsNullOrEmpty(Parent))
            builder["filter[parent]"] = Parent;

        return builder.ToString();
    }
}
