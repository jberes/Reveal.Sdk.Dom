using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class TabularDataSpec : DataSpec
    {
        public bool IsTransposed { get; set; }
        public List<Field> Fields { get; set; } = new List<Field>();
        public List<Field> TransposedFields { get; set; } = new List<Field>();
        public List<VisualizationFilter> QuickFilters { get; set; } = new List<VisualizationFilter>();
        public SummarizationSpec SummarizationSpec { get; set; }
        public List<AdditionalTable> AdditionalTables { get; set; } = new List<AdditionalTable>();
        public List<ServiceAdditionalTable> ServiceAdditionalTables { get; set; } = new List<ServiceAdditionalTable>();

        public TabularDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.TabularDataSpecType;
        }
    }
}
