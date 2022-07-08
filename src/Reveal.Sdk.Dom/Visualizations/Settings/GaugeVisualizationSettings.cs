using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GaugeVisualizationSettings : VisualizationSettings
    {
        [JsonProperty("SingleValueFormattingEnabled")]
        public bool ConditionalFormattingEnabled { get; set; } = true;

        [JsonProperty]
        [JsonConverter(typeof(StringEnumConverter))]
        internal GaugeViewType ViewType { get; set; } = GaugeViewType.Circular;
        public Bound Minimum { get; set; }
        public Bound Maximum { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        internal List<GaugeBand> GaugeBands { get; set; } = new List<GaugeBand>()
        {
            new GaugeBand()
            {
                Color = BandColorType.Green,
                Value = 80.0,
            },
            new GaugeBand()
            {
                Color = BandColorType.Yellow,
                Value = 50.0,
            },
            new GaugeBand()
            {
                Color = BandColorType.Red,
            },
        };

        [JsonProperty]
        internal string ValueColumnName { get; set; } //todo: what is this for?

        [JsonProperty]
        internal string LabelColumnName { get; set; } //todo: what is this for?

        [JsonProperty]
        internal string TargetColumnName { get; set; } //todo: what is this for?

        public GaugeVisualizationSettings()
        {
            SchemaTypeName = SchemaTypeNames.GaugeVisualizationSettingsType;
            VisualizationType = VisualizationTypes.GAUGE;
        }
    }
}
