using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public abstract class DataSourceItemBuilder : IDataSourceItemBuilder
    {
        protected DataSource DataSource { get; set; }
        protected DataSourceItem DataSourceItem { get; set; }

        public DataSourceItemBuilder(DataSourceProvider provider, string title) :
            this(new DataSource(), provider, title)
        { }

        public DataSourceItemBuilder(DataSource dataSource, DataSourceProvider provider, string title)
        {
            InitializeDataSource(dataSource, provider, title);
            InitializeDataSourceItem(title);
        }

        public virtual DataSourceItem Build()
        {
            //todo: need to revist to support xmla data sources
            //fields is only used for tabular data sources
            if (DataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item. Call the SetFields method and provide the fields.");

            return DataSourceItem;
        }

        public virtual IDataSourceItemBuilder Id(string id)
        {
            DataSourceItem.Id = id;
            return this;
        }

        public virtual IDataSourceItemBuilder Fields(IEnumerable<IField> fields)
        {
            DataSourceItem.Fields.Clear();
            DataSourceItem.Fields.AddRange(fields);
            return this;
        }

        public virtual IDataSourceItemBuilder Fields(params IField[] fields)
        {
            return Fields((IEnumerable<IField>)fields);
        }

        public virtual IDataSourceItemBuilder Subtitle(string subtitle)
        {
            DataSourceItem.Subtitle = subtitle;
            if (string.IsNullOrEmpty(DataSource.Subtitle))
                DataSource.Subtitle = subtitle;

            return this;
        }

        public virtual IDataSourceItemBuilder ConfigureDataSource(Action<DataSource> configureDataSource)
        {
            configureDataSource.Invoke(DataSource);
            UpdateDataSourceId(DataSource.Id);
            return this;
        }

        protected void UpdateDataSourceId(string id)
        {
            DataSource.Id = id;
            DataSourceItem.DataSourceId = id;
        }

        private void InitializeDataSource(DataSource dataSource, DataSourceProvider provider, string title)
        {
            DataSource = dataSource ?? new DataSource();
            DataSource.Provider = provider; // //todo: maybe this shouldn't go here. Each specific builder should be responsible for setting the provider
            if (string.IsNullOrEmpty(DataSource.Title))
                DataSource.Title = title;
        }

        private void InitializeDataSourceItem(string title)
        {
            DataSourceItem = new DataSourceItem
            {
                DataSource = DataSource,
                DataSourceId = DataSource.Id,
                Title = title,
            };
        }
    }
}
