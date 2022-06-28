using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ScatterMapVisualizationSettings : GeoMapBaseVisualizationSettings
    {
        public bool UseDifferentMarkers { get; set; }
        public DashboardScatterMapColorizationModeType ColorizationMode { get; set; }
        public ConditionalFormattingSpec ConditionalFormatting { get; set; }
        public bool ShowTileSource { get; set; } = true;
        public int ZoomThreshold { get; set; } = 3;
        public DashboardRectangle ZoomRectangle { get; set; }

        public ScatterMapVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.ScatterMapVisualizationSettingsType;
        }
    }

    //todo: rename and moved to proper folder
    public enum DashboardScatterMapColorizationModeType
    {
        Single,
        Range,
        ConditionalFormatting
    }

    //todo: rename and moved to proper folder
    public class DashboardRectangle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
