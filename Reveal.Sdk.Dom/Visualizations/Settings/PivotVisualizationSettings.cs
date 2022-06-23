using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class PivotVisualizationSettings : GridVisualizationSettings
    {
        public PivotVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.PivotVisualizationSettingsType;
            VisualizationType = VisualizationTypes.PIVOT;
        }
    }
}
