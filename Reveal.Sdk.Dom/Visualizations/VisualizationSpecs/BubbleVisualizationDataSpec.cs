using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class BubbleVisualizationDataSpec : ScatterVisualizationDataSpec
    {
        public List<MeasureColumnSpec> Radius { get; set; }
        
        public BubbleVisualizationDataSpec()
        {
            Radius = new List<MeasureColumnSpec>();
        }
    }
}
