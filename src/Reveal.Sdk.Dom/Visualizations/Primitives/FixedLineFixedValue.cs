using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class FixedLineFixedValue : FixedLine
    {
        public FixedLineFixedValue()
        {
            SchemaTypeName = SchemaTypeNames.FixedLineFixedValueType;
            FixedLineType = FixedLineType.FixedValue;
        }

        public double Value { get; set; }
    }
}
