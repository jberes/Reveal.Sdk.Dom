using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class VisualizationColumnStyle
    {
		public string ColumnName { get; set; }
		public double? Width { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public TextAlignment TextAlignment { get; set; } = TextAlignment.Inherit;
	}
}
