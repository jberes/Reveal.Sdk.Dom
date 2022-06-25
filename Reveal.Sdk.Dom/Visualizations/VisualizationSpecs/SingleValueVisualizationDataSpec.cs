using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class SingleValueVisualizationDataSpec : VisualizationDataSpec
    {
        public List<MeasureColumnSpec> Value { get; set; }

        public SingleValueVisualizationDataSpec()
        {
            Value = new List<MeasureColumnSpec>();
        }
    }
}
