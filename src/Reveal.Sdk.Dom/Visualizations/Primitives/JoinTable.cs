using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public sealed class JoinTable
    {
        public JoinTable(string alis, List<JoinCondition> joinConditions, DataSourceItem dataSourceItem) : this(alis, dataSourceItem)
        {
            JoinConditions = joinConditions;
        }

        public JoinTable(string alis, DataSourceItem dataSourceItem)
        {
            if (dataSourceItem == null)
                throw new System.ArgumentNullException($"JoinTable: {nameof(dataSourceItem)}");

            Alias = alis;            
            DataDefinition.DataSourceItem = dataSourceItem;
            DataDefinition.Fields.AddRange(dataSourceItem.Fields.Clone());
        }
        
        internal JoinTable()
        { }

        public string Alias { get; set; }

        [JsonProperty("DataSpec")]
        public TabularDataDefinition DataDefinition { get; set; } = new TabularDataDefinition();

        public List<JoinCondition> JoinConditions { get; set; } = new List<JoinCondition>();
    }
}
