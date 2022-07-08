using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class KpiTargetVisualizationSettings : IndicatorVisualizationSettings
    {
        public KpiTargetVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.IndicatorTargetVisualizationSettingsType;
            VisualizationType = VisualizationTypes.INDICATOR_TARGET;
        }
    }
}
