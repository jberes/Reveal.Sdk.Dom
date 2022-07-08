using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.DataSpecs;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ITabularVisualization<out TSettings> : IVisualization<TSettings, TabularDataSpec>
        where TSettings : VisualizationSettings
    {
        List<VisualizationFilter> Filters { get; }
    }
}