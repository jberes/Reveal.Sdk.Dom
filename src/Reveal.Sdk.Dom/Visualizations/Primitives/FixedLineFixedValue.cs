using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class FixedLineFixedValue : FixedLine
    {
        internal FixedLineFixedValue()
        {
            SchemaTypeName = SchemaTypeNames.FixedLineFixedValueType;
            FixedLineType = FixedLineType.FixedValue;
        }

        public FixedLineFixedValue(double value) : this(value, "Fixed Value")
        {
        }

        public FixedLineFixedValue(double value, string title) : this()
        {
            Value = value;
            Title = title;
            Identifier = $"_rp_flfv_{value}"; // hardcoded prefix used in RevealView
        }

        public double Value { get; set; } = 0.0;
    }
}
