namespace UpBank.Query;

public static class UpQueryExtensions
{
    #region Account

    public static UpQuery<UpAccountResource> FilterAccountType(
        this UpQuery<UpAccountResource> query,
        string accountType)
        => query.Filter("accountType", accountType);

    public static UpQuery<UpAccountResource> FilterOwnershipType(
        this UpQuery<UpAccountResource> query,
        string ownershipType)
        => query.Filter("ownershipType", ownershipType);

    #endregion

    #region Category

    public static UpQuery<UpCategoryResource> FilterParent(
        this UpQuery<UpCategoryResource> query,
        string parent)
        => query.Filter("parent", parent);

    #endregion

    #region Transaction

    public static UpQuery<UpTransactionResource> FilterStatus(
        this UpQuery<UpTransactionResource> query,
        string status)
        => query.Filter("status", status);

    public static UpQuery<UpTransactionResource> FilterSince(
        this UpQuery<UpTransactionResource> query,
        DateTime since)
        => query.Filter("since", since);

    public static UpQuery<UpTransactionResource> FilterUntil(
        this UpQuery<UpTransactionResource> query,
        DateTime until)
        => query.Filter("until", until);

    public static UpQuery<UpTransactionResource> FilterCategory(
        this UpQuery<UpTransactionResource> query,
        string category)
        => query.Filter("category", category);

    public static UpQuery<UpTransactionResource> FilterTag(
        this UpQuery<UpTransactionResource> query,
        string tag)
        => query.Filter("tag", tag);

    #endregion
}
