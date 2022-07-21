using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal class SummarizationSpec
    {
        public bool HideGrandTotalRow { get; set; }
        public bool HideGrandTotalCol { get; set; }
        public int? AdHocFields { get; set; }
        public List<SummarizationDimensionField> Rows { get; set; }
        public List<SummarizationDimensionField> Columns { get; set; }
        public List<SummarizationValueField> Values { get; set; }
        public List<AdHocExpandedElement> AdHocExpandedElements { get; set; }

        public SummarizationSpec()
        {
            Rows = new List<SummarizationDimensionField>();
            Columns = new List<SummarizationDimensionField>();
            Values = new List<SummarizationValueField>();
            AdHocExpandedElements = new List<AdHocExpandedElement>();
        }
    }
}
