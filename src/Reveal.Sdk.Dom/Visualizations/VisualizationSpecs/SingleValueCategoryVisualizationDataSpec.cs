using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class SingleValueCategoryVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumn> Value { get; set; }
		public DimensionColumn Category { get; set; }
		
		public SingleValueCategoryVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.SingleValueCategoryVisualizationDataSpecType;
			Value = new List<MeasureColumn>();
		}
	}
}
