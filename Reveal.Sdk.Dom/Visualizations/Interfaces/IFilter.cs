using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface IFilter
    {
        List<VisualizationFilter> Filters { get; }
    }
}