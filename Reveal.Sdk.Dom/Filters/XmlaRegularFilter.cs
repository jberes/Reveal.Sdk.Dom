using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Filters
{
    public class XmlaRegularFilter : Filter
    {
        public XmlaFilterRule FilterRule { get; set; }

        public XmlaRegularFilter()
        {
            SchemaTypeName = SchemaTypeNames.XmlaRegularFilterType;
        }
    }
}
