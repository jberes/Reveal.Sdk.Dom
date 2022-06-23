using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class IndicatorVisualizationDataSpecBase : LabelsVisualizationDataSpec
    {
		public DimensionColumnSpec Date { get; set; }
		public List<MeasureColumnSpec> Value { get; set; } = new List<MeasureColumnSpec>();
	}
}
