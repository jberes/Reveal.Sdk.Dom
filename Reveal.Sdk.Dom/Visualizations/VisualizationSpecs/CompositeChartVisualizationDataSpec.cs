using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class CompositeChartVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Chart1 { get; set; }
		public List<MeasureColumnSpec> Chart2 { get; set; }
		public CompositeChartVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.CompositeChartVisualizationDataSpecType;
			Chart1 = new List<MeasureColumnSpec>();
			Chart2 = new List<MeasureColumnSpec>();
		}
	}
}
