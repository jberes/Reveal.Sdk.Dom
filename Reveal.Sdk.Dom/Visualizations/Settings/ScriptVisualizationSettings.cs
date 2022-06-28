using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ScriptVisualizationSettings : VisualizationSettings
    {
        public string Language { get; set; }
        public string Script { get; set; }

        public ScriptVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.ScriptVisualizationSettingsType;
        }
    }
}
