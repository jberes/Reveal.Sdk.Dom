using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class PivotVisualizationDataSpec : HierarchyVisualizationDataSpec
    {        
		public List<DimensionColumnSpec> Columns { get; set; } = new List<DimensionColumnSpec>();
		public List<MeasureColumnSpec> Values { get; set; } = new List<MeasureColumnSpec>();
		public bool ShowGrandTotals { get; set; }

		public PivotVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.PivotVisualizationDataSpecType;
		}
	}
}
