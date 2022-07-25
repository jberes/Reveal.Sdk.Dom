using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    internal sealed class VisualizationColumnStyle
    {
		public string ColumnName { get; set; }
		public double? Width { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Alignment TextAlignment { get; set; } = Alignment.Inherit;
	}
}
