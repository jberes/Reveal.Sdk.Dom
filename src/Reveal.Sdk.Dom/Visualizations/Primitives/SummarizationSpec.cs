using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal sealed class SummarizationSpec
    {
        public bool HideGrandTotalRow { get; set; }
        public bool HideGrandTotalCol { get; set; }
        public int? AdHocFields { get; set; }
        public List<IDimensionDataField> Rows { get; set; } = new List<IDimensionDataField>();
        public List<IDimensionDataField> Columns { get; set; } = new List<IDimensionDataField>();
        public List<NumberDataField> Values { get; set; } = new List<NumberDataField>();
        public List<AdHocExpandedElement> AdHocExpandedElements { get; set; } = new List<AdHocExpandedElement>();
    }
}
