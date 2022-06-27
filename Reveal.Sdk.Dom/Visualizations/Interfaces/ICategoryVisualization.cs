using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ICategoryVisualization : IVisualization, ILabels, IValues
    {
        DimensionColumnSpec Category { get; set; }
    }
}