using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Filters;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations.DataSpecs
{
    public class TabularDataSpec : DataSpec
    {
        //not sure what this is for yet
        [JsonProperty]
        internal bool IsTransposed { get; set; }

        [JsonProperty]
        public List<Field> Fields { get; internal set; } = new List<Field>();

        //not sure what this is for yet
        [JsonProperty]
        internal List<Field> TransposedFields { get; set; } = new List<Field>();

        /// <summary>
        /// This is exposed via the Visualization.Filters property
        /// </summary>
        [JsonProperty]
        internal List<VisualizationFilter> QuickFilters { get; set; } = new List<VisualizationFilter>();

        //not sure what this is for yet
        [JsonProperty]
        internal SummarizationSpec SummarizationSpec { get; set; }

        //not sure what this is for yet
        [JsonProperty]
        internal List<AdditionalTable> AdditionalTables { get; set; } = new List<AdditionalTable>();

        //not sure what this is for yet
        [JsonProperty]
        internal List<ServiceAdditionalTable> ServiceAdditionalTables { get; set; } = new List<ServiceAdditionalTable>();

        public TabularDataSpec()
        {
            SchemaTypeName = SchemaTypeNames.TabularDataSpecType;
        }
    }
}
