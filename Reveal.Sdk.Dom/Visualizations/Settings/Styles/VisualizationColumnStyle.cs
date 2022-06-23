using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class VisualizationColumnStyle
    {
		public string ColumnName { get; set; }
		public double? Width { get; set; }

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public TextAlignment TextAlignment { get; set; } = TextAlignment.Inherit;
	}
}
