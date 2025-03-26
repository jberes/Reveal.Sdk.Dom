using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class FixedLineAverage : FixedLine
    {
        public FixedLineAverage()
        {
            SchemaTypeName = SchemaTypeNames.FixedLineAverageType;
            FixedLineType = FixedLineType.Average;
        }
    }
}
