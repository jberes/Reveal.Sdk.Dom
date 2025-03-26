using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class FixedLineMinimum : FixedLine
    {
        public FixedLineMinimum() : this("Minimum") { }

        public FixedLineMinimum(string title)
        {
            SchemaTypeName = SchemaTypeNames.FixedLineLowestType;
            FixedLineType = FixedLineType.Lowest;
            Identifier = "_rp_fll_"; // hardcoded value used in RevealView
            Title = title;
        }
    }
}
