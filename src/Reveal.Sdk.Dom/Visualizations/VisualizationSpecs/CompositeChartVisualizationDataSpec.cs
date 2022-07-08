using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class CompositeChartVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Chart1 { get; set; } = new List<MeasureColumnSpec>();
		public List<MeasureColumnSpec> Chart2 { get; set; } = new List<MeasureColumnSpec>();
		public CompositeChartVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.CompositeChartVisualizationDataSpecType;
		}
	}
}
