using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Filters;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Visualizations
{
    public abstract class Visualization<TSettings> : Visualization, ISettingsProvider<TSettings>, IFilterBindings
        where TSettings : VisualizationSettings, new()
    {
        protected Visualization(string title, DataSourceItem dataSourceItem) 
            : base(title, dataSourceItem) { }

        [JsonIgnore]
        public List<Binding> FilterBindings
        {
            get { return ((DataDefinitionBase)DataDefinition).Bindings.Bindings; }
        }

        [JsonProperty("ActionsModel", Order = 10)]
        public VisualizationLinker Linker { get; set; }

        [JsonProperty("VisualizationSettings", Order = 5)]
        public TSettings Settings { get; internal set; } = new TSettings();

        //todo: is it possible to create a Filters property that can properly handle both Tabular and Xmla data specs?
        //[JsonIgnore]
        //public List<VisualizationFilter> Filters
        //{
        //    get { return DataDefinition.QuickFilters; } //this works for tabluar
        //}
    }

    public abstract class Visualization : IVisualization, IParentDocument
    {
        protected Visualization(string title, DataSourceItem dataSourceItem)
        {
            Title = title;
            InitializeDataDefinition(dataSourceItem);
        }

        [JsonProperty(Order = 0)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonIgnore]
        public ChartType ChartType { get; protected set; } = ChartType.Unknown;

        [JsonProperty(Order = 1)]
        public string Title { get; set; }

        [JsonProperty(Order = 2)]
        public bool IsTitleVisible { get; set; } = true;

        [JsonProperty(Order = 3)]
        public int ColumnSpan { get; set; }

        [JsonProperty(Order = 4)]
        public int RowSpan { get; set; }

        [JsonIgnore]
        RdashDocument IParentDocument.Document { get; set; }

        [JsonProperty("DataSpec", Order = 6)]
        public IDataDefinition DataDefinition { get; internal set; }

        /// <summary>
        /// Gets or sets the description of the visualization.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the data source item for the visualization.
        /// </summary>
        /// <returns>The <see cref="DataSourceItem"/></returns>
        public DataSourceItem GetDataSourceItem()
        {
            var dataSourceItem = DataDefinition.DataSourceItem;
            if (DataDefinition is TabularDataDefinition tdd)
            {
                dataSourceItem.Fields = tdd.Fields.Clone();
            }

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
            if (DataDefinition == null || dataSourceItem == null)
                return;

            ((DataDefinitionBase)DataDefinition).DataSourceItem = dataSourceItem;
            if (DataDefinition is TabularDataDefinition tdd)
            {
                if (dataSourceItem.Fields == null || dataSourceItem.Fields.Count == 0)
                    throw new ArgumentException($"Field definitions for the data source item '{dataSourceItem.Title}' are required. Set the DataSourceitem.Fields property.");

                tdd.Fields = dataSourceItem.Fields.Clone();
            }
        }

        protected virtual void InitializeDataDefinition(DataSourceItem dataSourceItem)
        {
            if (dataSourceItem != null)
            {
                if (dataSourceItem.HasTabularData)
                {
                    DataDefinition = new TabularDataDefinition();
                }
                else
                {
                    DataDefinition = new XmlaDataDefinition();
                }

                UpdateDataSourceItem(dataSourceItem);
            }
        }
    }
}