using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ISparklineVisualization
    {
        DimensionColumnSpec Date { get; set; }

        List<MeasureColumnSpec> Values { get; }

        List<DimensionColumnSpec> Categories { get; }

        int NumberOfPeriods { get; set; }

        bool ShowIndicator { get; set; }
    }
}
