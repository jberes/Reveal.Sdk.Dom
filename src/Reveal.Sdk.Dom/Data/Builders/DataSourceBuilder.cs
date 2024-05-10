using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceBuilder : IDataSourceBuilder
    {
        protected DataSource DataSource { get; } = new DataSource();
        protected DataSourceItem DataSourceItem { get; } = new DataSourceItem();

        public DataSourceBuilder(DataSourceProvider provider, string title, string subtitle) :
            this(new DataSource(), provider, title, subtitle)
        { }

        public DataSourceBuilder(DataSource dataSource, DataSourceProvider provider, string title, string subtitle)
        {
            DataSource = dataSource ?? new DataSource();
            DataSource.Provider = provider;
            DataSourceItem.DataSource = DataSource;
            DataSourceItem.DataSourceId = DataSource.Id;
            SetTitle(title);
            SetSubtitle(subtitle);
        }

        public virtual DataSourceItem Build()
        {
            //todo: need to revist to support xmla data sources
            //fields is onlty used for tabular data sources
            if (DataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item. Call the SetFields method and provide the fields.");

            return DataSourceItem;
        }

        public virtual IDataSourceBuilder SetId(string id)
        {
            DataSourceItem.Id = id;
            return this;
        }

        public virtual IDataSourceBuilder SetFields(IEnumerable<IField> fields)
        {
            DataSourceItem.Fields.Clear();
            DataSourceItem.Fields.AddRange(fields);
            return this;
        }

        public virtual IDataSourceBuilder SetFields(params IField[] fields)
        {
            return SetFields((IEnumerable<IField>)fields);
        }

        public virtual void SetSubtitle(string subtitle)
        {
            DataSourceItem.Subtitle = subtitle;
            if (string.IsNullOrEmpty(DataSource.Subtitle))
                DataSource.Subtitle = subtitle;
        }

        public virtual void SetTitle(string title)
        {
            DataSourceItem.Title = title;
            if (string.IsNullOrEmpty(DataSource.Title))
                DataSource.Title = title;
        }

        public virtual IDataSourceBuilder ConfigureDataSource(Action<DataSource> configureDataSource)
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
    }

    public interface ISqlBuilder : IDataSourceBuilder
    {
        ISqlBuilder SetDatabase(string database);
        ISqlBuilder SetHost(string host);
        ISqlBuilder SetSchema(string schema);
        ISqlBuilder SetTable(string table);
    }

    public class SqlBuilder : DataSourceBuilder, ISqlBuilder
    {
        //bug: if the database is not provided, the DSI Title will not be shown in the UI

        public SqlBuilder(string title, string subtitle, DataSource dataSource) : 
            base(dataSource, DataSourceProvider.MicrosoftSqlServer, title, subtitle)
        {
            SetSchema("dbo");
            DataSource.Properties.SetItem("ServerAggregationDefault", true);
            DataSource.Properties.SetItem("ServerAggregationReadOnly", false);
            DataSourceItem.Properties.SetItem("ServerAggregation", true);
        }

        public ISqlBuilder SetDatabase(string database)
        {
            DataSource.Properties.SetItem("Database", database);
            DataSourceItem.Properties.SetItem("Database", database);
            return this;
        }

        public ISqlBuilder SetHost(string host)
        {
            DataSource.Properties.SetItem("Host", host);
            return this;
        }

        public ISqlBuilder SetSchema(string schema)
        {
            DataSourceItem.Properties.SetItem("Schema", schema);
            return this;
        }

        public ISqlBuilder SetTable(string table)
        {
            DataSourceItem.Properties.SetItem("Table", table);
            return this;
        }
    }
}
