using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Primitives;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class IndicatorTargetVisualizationDataSpec : IndicatorBaseVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Target { get; set; } = new List<MeasureColumnSpec>();

		[JsonConverter(typeof(StringEnumConverter))]
		public IndicatorTargetDateFilterType DateFilterType { get; set; } = IndicatorTargetDateFilterType.YearToDate;
		public DateRange CustomDateRange { get; set; }

		public IndicatorTargetVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.IndicatorTargetVisualizationDataSpecType;
		}
	}
}
