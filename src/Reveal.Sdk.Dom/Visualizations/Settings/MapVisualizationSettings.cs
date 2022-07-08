using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class MapVisualizationSettings : MapBaseVisualizationSettings
    {
        public DashboardMapLocationType LocationType { get; set; } = DashboardMapLocationType.Geocoding;

        [JsonProperty]
        internal string GeolocationColumnName { get; set; }

        public MapVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.MapVisualizationSettingsType;
        }
    }

    public enum DashboardMapLocationType
    {
        Geocoding,
        LatitudeLongitudeSingleField,
        LatitudeLongitudeFields
    }
}
