using Reveal.Sdk.Dom.Core.Constants;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.VisualizationSpecs
{
    internal class CategoryVisualizationDataSpec : LabelsVisualizationDataSpec
    {
        public CategoryVisualizationDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.CategoryVisualizationDataSpecType;
        }

        public DimensionColumn Category { get; set; }

        public List<MeasureColumn> Values { get; set; } = new List<MeasureColumn>();

        public List<IFixedLine> FixedLines { get; set; } = new List<IFixedLine>();
    }
}
