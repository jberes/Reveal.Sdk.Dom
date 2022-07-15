using Reveal.Sdk.Dom.Core.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ChartVisualizationSettings : VisualizationSettings
    {
        /// <summary>
		/// Gets or sets the chart type of the Visualization
		/// </summary>
        [JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		internal ChartType ChartType { get; set; }

		/// <summary>
		/// Gets or sets if the left axis will use the Logarithmic scale. Linear is used by default.
		/// </summary>
		[JsonProperty("LeftAxisLogarithmic")]
		public bool LeftAxisIsLogarithmic { get; set; }

		/// <summary>
		/// Gets or sets the minimum value for the left axis. Default value is 0.
		/// </summary>
		[JsonProperty]
		public double? LeftAxisMinValue { get; set; }

		/// <summary>
		/// Gets or sets the maximum value for the left axis. Default value is calculated automatically depending on the values.
		/// </summary>
		[JsonProperty]
		public double? LeftAxisMaxValue { get; set; }

        /// <summary>
		/// Gets or sets if the chart legend is displayed in the RevealView
		/// </summary>
		[JsonProperty("ShowLegends")]
		public bool ShowLegend { get; set; } = true;

        /// <summary>
		/// Gets or sets a trendline to apply to the visualization
		/// </summary>
		[JsonProperty("TrendlineType")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TrendlineType Trendline { get; set; }

		/// <summary>
		/// Gets or sets the color index for the visualization's starting color. A 0-based index offset is used to set colors instead of a color name.
		/// For example, an index of 5 would be the 6th color in the color scheme regardless of the theme colors being used.
		/// </summary>
		[JsonProperty("BrushOffsetIndex")]
		public int? StartColorIndex { get; set; }


		//todo: what are these?
		//[JsonProperty]
		//internal FinancialSettings Financial { get; set; } = new FinancialSettings();

		//[JsonProperty]
		//internal string LabelField { get; set; }

		//[JsonProperty]
		//internal string XAxisField { get; set; }

		//[JsonProperty]
		//internal string YAxisField { get; set; }

		//[JsonProperty]
		//internal string ZAxisField { get; set; }

		//[JsonProperty]
		//internal string ColorAxisField { get; set; }

		//[JsonProperty]
		//internal List<string> Series { get; set; } = new List<string>();

		//[JsonProperty]
		//internal List<string> LeftAxisFields { get; set; } = new List<string>();

		//[JsonProperty]
		//internal bool AllSeries { get; set; }


		//todo: does not apply to pie, doughnut, funnel, combo,
		[JsonProperty]
		internal bool ShowTotalsInTooltip { get; set; }

		//todo: looks like stack series charts only
		[JsonProperty]
		internal bool? IsPercentageDistributed { get; set; }

		//todo: looks like only applies to Pie and Doughnut charts
		[JsonProperty]
		internal int? PieStartPosition { get; set; }

		//todo: looks like only applies to Pie and Doughnut charts
		[JsonProperty]
		internal bool ShowZeroValuesInLegend { get; set; }

		//todo: looks like it only applies to Funnel Pie, and Doughnut
		[JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		internal LabelDisplayMode LabelDisplayMode { get; set; }

		public ChartVisualizationSettings()
        {
			SchemaTypeName = SchemaTypeNames.ChartVisualizationSettingsType;
			VisualizationType = VisualizationTypes.CHART;
		}
	}
}
