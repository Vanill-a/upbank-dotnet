namespace UpBank;

public class UpCategoryQueryBuilder : UpQueryBuilder
{
    public UpCategoryQueryBuilder FilterParent(string parent)
    {
        _Builder["filter[parent]"] = parent;
        return this;
    }
}
