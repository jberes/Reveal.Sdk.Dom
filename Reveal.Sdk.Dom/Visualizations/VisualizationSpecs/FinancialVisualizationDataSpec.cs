using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class FinancialVisualizationDataSpec : LabelsVisualizationDataSpec
    {
		public List<MeasureColumnSpec> Open { get; set; }
		public List<MeasureColumnSpec> High { get; set; }
		public List<MeasureColumnSpec> Low { get; set; }
		public List<MeasureColumnSpec> Close { get; set; }
		
		public FinancialVisualizationDataSpec()
		{
			Open = new List<MeasureColumnSpec>();
			High = new List<MeasureColumnSpec>();
			Low = new List<MeasureColumnSpec>();
			Close = new List<MeasureColumnSpec>();
		}
	}
}
