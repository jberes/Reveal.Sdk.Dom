using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class ScatterMapVisualizationDataSpec : VisualizationDataSpec
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
			MapColor = new List<MeasureColumnSpec>();
			Radius = new List<MeasureColumnSpec>();
			IsSingleLocationField = false;
			IsColorByValue = true;
		}
	}
}
