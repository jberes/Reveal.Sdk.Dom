using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class FixedLineMaximum : FixedLine
    {
        public FixedLineMaximum() : this("Maximum") { }

        public FixedLineMaximum(string title)
        {
            SchemaTypeName = SchemaTypeNames.FixedLineHighestType;
            FixedLineType = FixedLineType.Highest;
            Identifier = "_rp_flh_"; // hardcoded value used in RevealView
            Title = title;
        }
    }
}
