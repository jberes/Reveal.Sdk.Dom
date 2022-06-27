using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class BubbleVisualizationDataSpec : ScatterVisualizationDataSpec
    {
        public List<MeasureColumnSpec> Radius { get; set; }
        
        public BubbleVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.BubbleVisualizationDataSpecType;
            Radius = new List<MeasureColumnSpec>();
        }
    }
}
