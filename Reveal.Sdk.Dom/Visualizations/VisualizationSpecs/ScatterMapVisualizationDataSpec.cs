using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class ScatterMapVisualizationDataSpec : VisualizationDataSpec
    {
		public bool IsSingleLocationField { get; set; }
		public bool IsColorByValue { get; set; }
		public DimensionColumnSpec Location { get; set; }
		public DimensionColumnSpec Longitude { get; set; }
		public DimensionColumnSpec Label { get; set; }
		public DimensionColumnSpec MapColorCategory { get; set; }
		public List<MeasureColumnSpec> MapColor { get; set; }
		public List<MeasureColumnSpec> Radius { get; set; }

		public ScatterMapVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.ScatterMapVisualizationDataSpecType;
			MapColor = new List<MeasureColumnSpec>();
			Radius = new List<MeasureColumnSpec>();
			IsSingleLocationField = false;
			IsColorByValue = true;
		}
	}
}
