using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class DimensionColumnSpec : ColumnSpec
    {
        public SummarizationDimensionField SummarizationField { get; set; }
        public XmlaDimensionElement XmlaElement { get; set; }

        public DimensionColumnSpec()
        {
            SchemaTypeName = SchemaTypeNames.DimensionColumnSpecType;
        }
    }
}
