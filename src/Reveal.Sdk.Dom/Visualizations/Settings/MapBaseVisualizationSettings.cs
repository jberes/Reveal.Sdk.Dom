using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class MapBaseVisualizationSettings : VisualizationSettings
    {
        public DashboardMapVisualizationType MapType { get; set; } = DashboardMapVisualizationType.Standard;

        [JsonProperty]
        internal string LatitudeColumnName { get; set; }

        [JsonProperty]
        internal string LongitudeColumnName { get; set; }

        [JsonProperty]
        internal string LatitudeLongitudeColumnName { get; set; }

        [JsonProperty]
        internal string DisplayColumnName { get; set; }

        [JsonProperty]
        internal string DisplayValueColumnName { get; set; }

        [JsonProperty]
        internal string DisplayValueColor { get; set; }
    }

    public enum DashboardMapVisualizationType
    {
        Standard,
        Satellite,
        Hybrid
    }
}
