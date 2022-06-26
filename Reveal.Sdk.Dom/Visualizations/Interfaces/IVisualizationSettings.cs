using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal interface IVisualizationSettings<T>
        where T : VisualizationSettings
    {
        T Settings { get; }
    }
}