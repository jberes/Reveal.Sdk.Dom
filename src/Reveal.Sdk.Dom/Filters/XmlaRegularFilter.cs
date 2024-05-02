using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Filters
{
    public sealed class XmlaRegularFilter : FilterBase
    {
        public XmlaFilterRule FilterRule { get; set; }

        public XmlaRegularFilter()
        {
            SchemaTypeName = SchemaTypeNames.XmlaRegularFilterType;
        }
    }
}
