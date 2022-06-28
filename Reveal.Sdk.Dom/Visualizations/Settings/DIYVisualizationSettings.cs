using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class DIYVisualizationSettings : VisualizationSettings
    {
        public string Title { get; set; }
        public string Url { get; set; }

        public DIYVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.DiyVisualizationSettingsType;
        }
    }
}
