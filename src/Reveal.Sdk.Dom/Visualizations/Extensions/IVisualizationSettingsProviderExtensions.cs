using Reveal.Sdk.Dom.Visualizations.Settings;
using System;

namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IVisualizationSettingsProviderExtensions
    {
        internal static T ConfigureSettings<T, TSettings>(this T visualization, Action<TSettings> setting)
            where T : ISettingsProvider<TSettings>
            where TSettings : VisualizationSettings
        {
            setting.Invoke(visualization.Settings);
            return visualization;
        }
    }
}
