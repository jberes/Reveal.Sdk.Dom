using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public class FixedLineHighest : FixedLine
    {
        public FixedLineHighest()
        {
            SchemaTypeName = SchemaTypeNames.FixedLineHighestType;
            FixedLineType = FixedLineType.Highest;
        }
    }
}
