using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IAxis
    {
        List<MeasureColumnSpec> XAxes { get; }
        List<MeasureColumnSpec> YAxes { get; }
    }
}
