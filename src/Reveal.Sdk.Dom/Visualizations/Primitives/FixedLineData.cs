using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class FixedLineData : FixedLine
    {
        public FixedLineData()
        {
            SchemaTypeName = SchemaTypeNames.FixedLineDataType;
            FixedLineType = FixedLineType.Data;
        }

        public MeasureColumn DataField { get; set; }
    }
}
