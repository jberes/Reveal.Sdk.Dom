using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ITabularVisualization<out TSettings> : IVisualization<TSettings, TabularDataDefinition>
        where TSettings : VisualizationSettings
    {
        List<VisualizationFilter> Filters { get; }
    }
}