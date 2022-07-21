using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IAxis
    {
        List<MeasureColumn> XAxes { get; }
        List<MeasureColumn> YAxes { get; }
    }
}
