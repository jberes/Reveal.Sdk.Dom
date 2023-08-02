using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class TabularVisualizationBase<TSettings> : Visualization<TSettings, TabularDataDefinition>, ITabularVisualization, ITabularDataDefinitionProvider
        where TSettings : VisualizationSettings, new()
    {
        protected TabularVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title)
        {
            DataDefinition = new TabularDataDefinition
            {
                DataSourceItem = dataSourceItem,
                Fields = dataSourceItem?.Fields.Clone()
            };
        }

        [JsonIgnore]
        public List<VisualizationFilter> Filters
        {
            get { return DataDefinition.QuickFilters; }
        }
    }
}