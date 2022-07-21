using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class SingleValueLabelsVisualizationDataSpec : LabelsVisualizationDataSpec
    {
        public List<MeasureColumn> Value { get; set; } = new List<MeasureColumn>();

        public SingleValueLabelsVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.SingleValueLabelsVisualizationDataSpecType;
        }
    }
}
