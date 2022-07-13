using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Settings
{
    public class ChartVisualizationSettings : VisualizationSettings
    {
        [JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		internal ChartType ChartType { get; set; }

		[JsonProperty]
		internal bool AllSeries { get; set; }

		public bool ShowLegends { get; set; } = true;

		[JsonConverter(typeof(StringEnumConverter))]
		public TrendlineType TrendlineType { get; set; }

		[JsonProperty]
		internal bool SingleAxisMode { get; set; }

		[JsonProperty]
		internal FinancialSettings Financial { get; set; } = new FinancialSettings();

		[JsonProperty]
		internal string LabelField { get; set; }

		[JsonProperty]
		internal string XAxisField { get; set; }

		[JsonProperty]
		internal string YAxisField { get; set; }

		[JsonProperty]
		internal string ZAxisField { get; set; }

		[JsonProperty]
		internal string ColorAxisField { get; set; }

		[JsonProperty]
		internal List<string> Series { get; set; } = new List<string>();

		[JsonProperty]
		internal List<string> LeftAxisFields { get; set; } = new List<string>();

		[JsonProperty]
		internal List<string> RightAxisFields { get; set; } = new List<string>();

		[JsonProperty]
		internal bool LeftAxisLogarithmic { get; set; }

		[JsonProperty]
		internal bool RightAxisLogarithmic { get; set; }

		[JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		internal LabelDisplayMode LabelDisplayMode { get; set; }

		[JsonProperty]
		internal bool? IsPercentageDistributed { get; set; }

		[JsonProperty]
		internal double? LeftAxisMinValue { get; set; }

		[JsonProperty]
		internal double? LeftAxisMaxValue { get; set; }

		[JsonProperty]
		internal double? RightAxisMinValue { get; set; }

		[JsonProperty]
		internal double? RightAxisMaxValue { get; set; }

		[JsonProperty]
		internal int? BrushOffsetIndex { get; set; }

		[JsonProperty]
		internal int? PieStartPosition { get; set; }

		[JsonProperty]
		internal bool ShowTotalsInTooltip { get; set; }

		[JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		internal ChartType CompositeChartType1 { get; set; }

		[JsonProperty]
		[JsonConverter(typeof(StringEnumConverter))]
		internal ChartType CompositeChartType2 { get; set; }

		[JsonProperty]
		internal bool CompositeChartTypesSwapped { get; set; }

		[JsonProperty]
		internal bool ShowZeroValuesInLegend { get; set; }

        public ChartVisualizationSettings()
        {
			SchemaTypeName = SchemaTypeNames.ChartVisualizationSettingsType;
			VisualizationType = VisualizationTypes.CHART;
		}
	}
}
