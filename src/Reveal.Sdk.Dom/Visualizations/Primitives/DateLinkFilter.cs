namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class DateLinkFilter : LinkFilter
    {
        public DateLinkFilter()
        {
            Name = "Date Filter";
            Value = "_date.Date Filter";
            TargetFilterId = "_date";
            Type = LinkFilterType.GlobalFilter;
        }
    }
}
