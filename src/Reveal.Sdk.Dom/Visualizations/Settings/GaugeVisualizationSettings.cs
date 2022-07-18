using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GaugeVisualizationSettings : GaugeVisualizationSettings<GaugeBand>
    {
        public GaugeVisualizationSettings() : base() { }

        /// <summary>
        /// Gets or sets the minimum value for the gauge.
        /// </summary>
        public Bound Minimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum value for the gauge.
        /// </summary>
        public Bound Maximum { get; set; }

        /// <summary>
        /// Gets or sets the type of value comparison to apply to the <see cref="GaugeVisualizationSettings{TBand}.UpperBand"/>, <see cref="GaugeVisualizationSettings{TBand}.MiddleBand"/>, and <see cref="GaugeVisualizationSettings{TBand}.LowerBand"/>.
        /// </summary>
        [JsonIgnore]
        public ValueComparisonType ValueComparisonType
        {
            get { return GaugeBands.First().ValueComparisonType; }
            set
            {
                foreach (var item in GaugeBands)
                {
                    item.ValueComparisonType = value;
                }
            }
        }
    }

    public abstract class GaugeVisualizationSettings<TBand> : VisualizationSettings
        where TBand : Band, new()
    {
        protected GaugeVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.GaugeVisualizationSettingsType;
            VisualizationType = VisualizationTypes.GAUGE;

            GaugeBands = new List<TBand>()
            {
                UpperBand,
                MiddleBand,
                LowerBand
            };
        }

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal GaugeViewType ViewType { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        internal List<TBand> GaugeBands { get; set; }

        /// <summary>
        /// Gets the formatting band for values that are greater than or equal to the <see cref="UpperBand"/> value.
        /// </summary>
        [JsonIgnore]
        public TBand UpperBand { get; } = new TBand() { Color = BandColor.Green, Value = 80.0 };

        /// <summary>
        /// Gets the formatting band for values that are greater than or equal to the <see cref="MiddleBand"/> value, and less than the <see cref="UpperBand"/> value.
        /// </summary>
        [JsonIgnore]
        public TBand MiddleBand { get; } = new TBand() { Color = BandColor.Yellow, Value = 50.0 };

        /// <summary>
        /// Gets the formatting band for values that are less than the <see cref="MiddleBand"/> value.
        /// </summary>
        [JsonIgnore]
        public TBand LowerBand { get; } = new TBand() { Color = BandColor.Red };
    }
}

