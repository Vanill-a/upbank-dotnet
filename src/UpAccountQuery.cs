using System.Text.Json.Serialization;
using System.Web;

namespace UpBank;

public class UpAccountQuery : IUpQuery
{
    [JsonPropertyName("size")]
    public int? PageSize { get; set; }

    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("ownershipType")]
    public string? OwnershipType { get; set; }

    public string? GetQueryString()
    {
        var builder = HttpUtility.ParseQueryString(string.Empty);

        if (PageSize.HasValue)
            builder["page[size]"] = Convert.ToString(PageSize);

        if (AccountType is not null)
            builder["filter[accountType]"] = AccountType;

        if (OwnershipType is not null)
            builder["filter[ownershipType]"] = OwnershipType;

        return builder.ToString();
    }
}
