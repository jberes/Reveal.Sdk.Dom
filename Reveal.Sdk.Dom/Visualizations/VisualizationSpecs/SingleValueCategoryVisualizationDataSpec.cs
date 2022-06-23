using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class SingleValueCategoryVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Value { get; set; }
		public DimensionColumnSpec Category { get; set; }
		
		public SingleValueCategoryVisualizationDataSpec()
		{
			Value = new List<MeasureColumnSpec>();
		}
	}
}
