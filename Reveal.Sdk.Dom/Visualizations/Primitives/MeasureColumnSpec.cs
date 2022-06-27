using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class MeasureColumnSpec : ColumnSpec
    {
        public SummarizationValueField SummarizationField { get; set; }
        public XmlaMeasure XmlaMeasure { get; set; }

        public MeasureColumnSpec()
        {
            SchemaTypeName = SchemaTypeNames.MeasureColumnSpecType;
        }
    }
}