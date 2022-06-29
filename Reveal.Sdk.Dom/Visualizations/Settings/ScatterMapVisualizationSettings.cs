using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ScatterMapVisualizationSettings : GeoMapBaseVisualizationSettings
    {
        [JsonProperty]
        internal bool UseDifferentMarkers { get; set; }

        [JsonProperty]
        internal DashboardScatterMapColorizationModeType ColorizationMode { get; set; } = DashboardScatterMapColorizationModeType.Range;

        [JsonProperty]
        internal ConditionalFormattingSpec ConditionalFormatting { get; set; }

        [JsonProperty]
        internal bool ShowTileSource { get; set; } = true;

        [JsonProperty]
        internal int ZoomThreshold { get; set; } = 3;

        [JsonProperty]
        internal DashboardRectangle ZoomRectangle { get; set; }

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
