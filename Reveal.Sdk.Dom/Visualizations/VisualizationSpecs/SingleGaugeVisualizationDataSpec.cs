using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    public class SingleGaugeVisualizationDataSpec : SingleValueVisualizationDataSpec
    {
        public DimensionColumnSpec Label { get; set; }

        public SingleGaugeVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.SingleGaugeVisualizationDataSpecType;
        }
    }
}
