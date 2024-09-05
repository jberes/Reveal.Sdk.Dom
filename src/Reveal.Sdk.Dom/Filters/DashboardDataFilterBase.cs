using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Filters
{
    public abstract class DashboardDataFilterBase : DashboardFilter
    {
        public bool IsDynamic { get; set; } = true;
        public bool AllowMultipleSelection { get; set; } = true;
        public bool AllowEmptySelection { get; set; } = true;
        public bool SortByLabel { get; set; } = true;
        public List<FilterItem> SelectedItems { get; set; } = new List<FilterItem>();
    }
}
