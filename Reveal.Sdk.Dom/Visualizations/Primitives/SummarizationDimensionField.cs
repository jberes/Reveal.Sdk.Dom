using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class SummarizationDimensionField : SummarizationField
    {
        public List<string> DrillDownElements { get; set; } = new List<string>();
        public List<string> ExpandedItems { get; set; } = new List<string>();
        public string SortByField { get; set; }

        public SummarizationDimensionField() : this(string.Empty) { }

        public SummarizationDimensionField(string fieldName) : base(fieldName) { }
    }
}
