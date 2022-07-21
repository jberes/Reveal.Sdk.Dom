using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
	internal class ScatterMapVisualizationDataSpec : VisualizationDataSpec
    {
		public bool IsSingleLocationField { get; set; }
		public bool IsColorByValue { get; set; } = true;
		public DimensionColumn Location { get; set; }
		public DimensionColumn Longitude { get; set; }
		public DimensionColumn Label { get; set; }
		public DimensionColumn MapColorCategory { get; set; }
		public List<MeasureColumn> MapColor { get; set; } = new List<MeasureColumn>();
		public List<MeasureColumn> Radius { get; set; } = new List<MeasureColumn>();

		public ScatterMapVisualizationDataSpec()
		{
			SchemaTypeName = SchemaTypeNames.ScatterMapVisualizationDataSpecType;
		}
	}
}
