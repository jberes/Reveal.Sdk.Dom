using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class SingleValueCategoryVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Value { get; set; }
		public DimensionColumnSpec Category { get; set; }
		
		public SingleValueCategoryVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.SingleValueCategoryVisualizationDataSpecType;
			Value = new List<MeasureColumnSpec>();
		}
	}
}
