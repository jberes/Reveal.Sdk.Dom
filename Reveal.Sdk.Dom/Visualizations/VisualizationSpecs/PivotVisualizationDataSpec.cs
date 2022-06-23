using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class PivotVisualizationDataSpec : HierarchyVisualizationDataSpec
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
