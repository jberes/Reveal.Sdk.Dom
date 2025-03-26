using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class FixedLineAverage : FixedLine
    {
        public FixedLineAverage() : this("Average") { }

        public FixedLineAverage(string title)
        {
            SchemaTypeName = SchemaTypeNames.FixedLineAverageType;
            FixedLineType = FixedLineType.Average;
            Identifier = "_rp_fla_"; // hardcoded value used in RevealView
            Title = title;
        }
    }
}
