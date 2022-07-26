using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class MapZoomRectangle
    {
        /// <summary>
        /// Gets or sets the longitude of the top-left corner of the map. This will need to be adjusted based on the map shape being used.
        /// </summary>
        [JsonProperty("X")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the top-left corner of the map.
        /// </summary>
        [JsonProperty("Y")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the degrees of longitude.
        /// </summary>
        [JsonProperty("Width")]
        public double DegreesLongitude { get; set; }

        /// <summary>
        /// Gets or sets the degrees of latitude.
        /// </summary>
        [JsonProperty("Height")]
        public double DegreesLatitude { get; set; }
    }
}
