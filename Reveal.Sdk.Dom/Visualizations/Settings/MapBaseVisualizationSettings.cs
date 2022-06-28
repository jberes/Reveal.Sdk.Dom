namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class MapBaseVisualizationSettings : VisualizationSettings
    {
        public DashboardMapVisualizationType MapType { get; set; } = DashboardMapVisualizationType.Standard;
        public string LatitudeColumnName { get; set; }
        public string LongitudeColumnName { get; set; }
        public string LatitudeLongitudeColumnName { get; set; }
        public string DisplayColumnName { get; set; }
        public string DisplayValueColumnName { get; set; }
        public string DisplayValueColor { get; set; }
    }

    public enum DashboardMapVisualizationType
    {
        Standard,
        Satellite,
        Hybrid
    }
}
