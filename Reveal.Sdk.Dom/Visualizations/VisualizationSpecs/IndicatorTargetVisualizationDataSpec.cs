using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Primitives;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class KpiTargetVisualizationDataSpec : IndicatorVisualizationDataSpecBase
    {
		public List<MeasureColumnSpec> Target { get; set; } = new List<MeasureColumnSpec>();

		[JsonConverter(typeof(JsonStringEnumConverter))]
		public IndicatorTargetDateFilterType DateFilterType { get; set; } = IndicatorTargetDateFilterType.YearToDate;
		public DateRange CustomDateRange { get; set; }

		public KpiTargetVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.IndicatorTargetVisualizationDataSpecType;
		}
	}
}
