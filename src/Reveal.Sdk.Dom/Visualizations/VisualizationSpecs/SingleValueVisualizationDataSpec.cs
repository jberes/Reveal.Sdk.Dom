using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class SingleValueVisualizationDataSpec : VisualizationDataSpec
    {
        public List<MeasureColumn> Value { get; set; }

        public SingleValueVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.SingleValueVisualizationDataSpecType;
            Value = new List<MeasureColumn>();
        }
    }
}
