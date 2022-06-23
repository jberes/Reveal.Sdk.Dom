using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class GaugeVisualizationSettings : VisualizationSettings
    {
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public GaugeViewType ViewType { get; set; } = GaugeViewType.Circular;
		public Bound Minimum { get; set; }
		public Bound Maximum { get; set; }
		public List<GaugeBand> GaugeBands { get; set; } = new List<GaugeBand>();
		public string ValueColumnName { get; set; }
		public string LabelColumnName { get; set; }
		public string TargetColumnName { get; set; }
		public bool SingleValueFormattingEnabled { get; set; } = true;

        public GaugeVisualizationSettings()
        {
			SchemaTypeName = SchemaTypeNames.GaugeVisualizationSettingsType;
			VisualizationType = VisualizationTypes.GAUGE;
		}
	}
}
