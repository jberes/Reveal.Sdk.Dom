using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceBuilder : IDataSourceBuilder
    {
        protected DataSource DataSource { get; } = new DataSource();
        protected DataSourceItem DataSourceItem { get; } = new DataSourceItem();

        public DataSourceBuilder(DataSourceProvider provider, string title, string id) :
            this(new DataSource(), provider, title, id)
        { }

        public DataSourceBuilder(DataSource dataSource, DataSourceProvider provider, string title, string id)
        {
            DataSource = dataSource ?? new DataSource();
            DataSource.Provider = provider;
            DataSourceItem.DataSource = DataSource;
            DataSourceItem.DataSourceId = DataSource.Id;
            SetTitle(title);
            Id(id);
        }

        public virtual DataSourceItem Build()
        {
            //todo: need to revist to support xmla data sources
            //fields is onlty used for tabular data sources
            if (DataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item. Call the SetFields method and provide the fields.");

            return DataSourceItem;
        }

        public virtual IDataSourceBuilder Id(string id)
        {
            DataSourceItem.Id = id;
            return this;
        }

        public virtual IDataSourceBuilder Fields(IEnumerable<IField> fields)
        {
            DataSourceItem.Fields.Clear();
            DataSourceItem.Fields.AddRange(fields);
            return this;
        }

        public virtual IDataSourceBuilder Fields(params IField[] fields)
        {
            return Fields((IEnumerable<IField>)fields);
        }

        public virtual IDataSourceBuilder Subtitle(string subtitle)
        {
            DataSourceItem.Subtitle = subtitle;
            if (string.IsNullOrEmpty(DataSource.Subtitle))
                DataSource.Subtitle = subtitle;

            return this;
        }

        public virtual IDataSourceBuilder ConfigureDataSource(Action<DataSource> configureDataSource)
        {
            configureDataSource.Invoke(DataSource);
            UpdateDataSourceId(DataSource.Id);
            return this;
        }

        protected virtual void SetTitle(string title)
        {
            DataSourceItem.Title = title;
            if (string.IsNullOrEmpty(DataSource.Title))
                DataSource.Title = title;
        }

        protected void UpdateDataSourceId(string id)
        {
            DataSource.Id = id;
            DataSourceItem.DataSourceId = id;
        }
    }
}
