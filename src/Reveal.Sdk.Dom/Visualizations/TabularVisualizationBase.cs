using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class TabularVisualizationBase<TSettings> : Visualization<TSettings, TabularDataDefinition>, ITabularVisualization
        where TSettings : VisualizationSettings, new()
    {
        protected TabularVisualizationBase(string title, DataSourceItem dataSourceItem) : base(title)
        {
            DataDefinition = new TabularDataDefinition();
            UpdateDataSourceItem(dataSourceItem);
        }

        [JsonIgnore]
        public List<VisualizationFilter> Filters
        {
            get { return DataDefinition.QuickFilters; }
        }

        /// <summary>
        /// Gets the data source item for the visualization.
        /// </summary>
        /// <returns>The <see cref="DataSourceItem"/></returns>
        public DataSourceItem GetDataSourceItem()
        {
            var dataSourceItem = DataDefinition.DataSourceItem;
            dataSourceItem.Fields = DataDefinition.Fields.Clone();

            IParentDocument viz = this;
            dataSourceItem.DataSource = viz.Document.DataSources.Where(x => x.Id == dataSourceItem.DataSourceId).First();
            if (dataSourceItem.ResourceItem != null)
                dataSourceItem.ResourceItemDataSource = viz.Document.DataSources.Where(x => x.Id == dataSourceItem.ResourceItem.DataSourceId).First();

            return dataSourceItem;
        }

        /// <summary>
        /// Updates the data source item and available fields for the visualization.
        /// </summary>
        /// <param name="dataSourceItem">The <see cref="DataSourceItem"/> created with a data source builder.</param>
        public void UpdateDataSourceItem(DataSourceItem dataSourceItem)
        {
            DataDefinition.DataSourceItem = dataSourceItem;
            DataDefinition.Fields = dataSourceItem?.Fields.Clone();
        }
    }
}