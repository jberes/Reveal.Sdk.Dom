using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class ScatterMapVisualizationDataSpec : VisualizationDataSpec
    {
		public bool IsSingleLocationField { get; set; }
		public bool IsColorByValue { get; set; } = true;
		public DimensionColumnSpec Location { get; set; }
		public DimensionColumnSpec Longitude { get; set; }
		public DimensionColumnSpec Label { get; set; }
		public DimensionColumnSpec MapColorCategory { get; set; }
		public List<MeasureColumnSpec> MapColor { get; set; } = new List<MeasureColumnSpec>();
		public List<MeasureColumnSpec> Radius { get; set; } = new List<MeasureColumnSpec>();

		public ScatterMapVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.ScatterMapVisualizationDataSpecType;
		}
	}
}
