using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class CategoryVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public DimensionColumnSpec Category { get; set; }

		public List<MeasureColumnSpec> Values { get; set; } = new List<MeasureColumnSpec>();

		public CategoryVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.CategoryVisualizationDataSpecType;
		}
	}
}
