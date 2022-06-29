using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class SingleRowVisualizationSettings : VisualizationSettings
    {
        public SingleRowVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.SingleRowVisualizationSettingsType;
            VisualizationType = VisualizationTypes.SINGLE_ROW;
        }
    }
}
