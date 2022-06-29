using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GeoMapBaseVisualizationSettings : VisualizationSettings
    {
        public bool ShowLegends { get; set; } = true;
        internal string Region { get; set; }
        public int? ColorIndex { get; set; } = -1;

        public GeoMapBaseVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.GeoMapBaseVisualizationSettingsType;
        }
    }
}
