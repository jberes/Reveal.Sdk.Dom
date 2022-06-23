using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class CompositeChartVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Chart1 { get; set; }
		public List<MeasureColumnSpec> Chart2 { get; set; }
		public CompositeChartVisualizationDataSpec()
		{
			Chart1 = new List<MeasureColumnSpec>();
			Chart2 = new List<MeasureColumnSpec>();
		}
	}
}
