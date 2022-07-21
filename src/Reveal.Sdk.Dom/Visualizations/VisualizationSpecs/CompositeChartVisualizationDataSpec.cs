using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class CompositeChartVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumn> Chart1 { get; set; } = new List<MeasureColumn>();
		public List<MeasureColumn> Chart2 { get; set; } = new List<MeasureColumn>();
		public CompositeChartVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.CompositeChartVisualizationDataSpecType;
		}
	}
}
