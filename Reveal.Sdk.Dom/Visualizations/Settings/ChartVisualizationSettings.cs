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
		public bool AllSeries { get; set; }
		public bool ShowLegends { get; set; } = true;

		[JsonConverter(typeof(StringEnumConverter))]
		public TrendlineType TrendlineType { get; set; }		
		public bool SingleAxisMode { get; set; }
		public FinancialSettings Financial { get; set; }
		public string LabelField { get; set; }
		public string XAxisField { get; set; }
		public string YAxisField { get; set; }
		public string ZAxisField { get; set; }
		public string ColorAxisField { get; set; }
		public List<string> Series { get; set; }
		public List<string> LeftAxisFields { get; set; }
		public List<string> RightAxisFields { get; set; }
		public bool LeftAxisLogarithmic { get; set; }
		public bool RightAxisLogarithmic { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public LabelDisplayMode LabelDisplayMode { get; set; }
		public bool? IsPercentageDistributed { get; set; }
		public double? LeftAxisMinValue { get; set; }
		public double? LeftAxisMaxValue { get; set; }
		public double? RightAxisMinValue { get; set; }
		public double? RightAxisMaxValue { get; set; }
		public int? BrushOffsetIndex { get; set; }
		public int? PieStartPosition { get; set; }
		public bool ShowTotalsInTooltip { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ChartType CompositeChartType1 { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ChartType CompositeChartType2 { get; set; }
		public bool CompositeChartTypesSwapped { get; set; }
		public bool ShowZeroValuesInLegend { get; set; }

        public ChartVisualizationSettings()
        {
			SchemaTypeName = SchemaTypeNames.ChartVisualizationSettingsType;
			VisualizationType = VisualizationTypes.CHART;
			Series = new List<string>();
			LeftAxisFields = new List<string>();
			RightAxisFields = new List<string>();
		}
	}
}
