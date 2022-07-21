using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class IndicatorTargetVisualizationDataSpec : IndicatorBaseVisualizationDataSpec
    {
		public List<MeasureColumn> Target { get; set; } = new List<MeasureColumn>();

		[JsonConverter(typeof(StringEnumConverter))]
		public KpiGoalPeriod DateFilterType { get; set; } = KpiGoalPeriod.YearToDate;
		public DateRange CustomDateRange { get; set; }

		public IndicatorTargetVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.IndicatorTargetVisualizationDataSpecType;
		}
	}
}
