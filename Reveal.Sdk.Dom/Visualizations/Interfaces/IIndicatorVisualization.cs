using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IIndicatorVisualization : IVisualization
    {
        DimensionColumnSpec Date { get; set; }

        List<DimensionColumnSpec> Categories { get; }

        List<MeasureColumnSpec> Values { get; }
    }
}