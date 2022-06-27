using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class ChoroplethMapVisualizationDataSpec : SingleValueLabelsVisualizationDataSpec
    {
        public DimensionColumnSpec MapColor { get; set; }

        public ChoroplethMapVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.ChoroplethMapVisualizationDataSpecType;
        }
    }
}
