using Reveal.Sdk.Dom.Visualizations.Settings;

namespace Reveal.Sdk.Dom.Visualizations
{
    public interface ISettingsProvider<out TSettings> where TSettings : VisualizationSettings
    {
        TSettings Settings { get; }
    }
}