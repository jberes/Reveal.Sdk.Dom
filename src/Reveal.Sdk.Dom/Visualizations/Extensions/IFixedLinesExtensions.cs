using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IFixedLinesExtensions
    {
        public static T AddFixedLine<T>(this T visualization, IFixedLine fixedLine)
            where T : IFixedLines
        {
            // RULES:
            // - Average, Lowest, Highest can only be added once
            // - Data can be added multiple times, but only once per data field
            // - Fixed Value can be added any number of times

            if (fixedLine is FixedLineAverage && visualization.FixedLines.Any(fl => fl is FixedLineAverage))
                return visualization;

            if (fixedLine is FixedLineMinimum && visualization.FixedLines.Any(fl => fl is FixedLineMinimum))
                return visualization;

            if (fixedLine is FixedLineMaximum && visualization.FixedLines.Any(fl => fl is FixedLineMaximum))
                return visualization;

            if (fixedLine is FixedLineData data)
            {
                if (visualization.FixedLines.OfType<FixedLineData>().Any(f => f.DataField.DataField?.FieldName == data.DataField.DataField?.FieldName))
                    return visualization;
            }

            visualization.FixedLines.Add(fixedLine);

            return visualization;
        }
    }
}
