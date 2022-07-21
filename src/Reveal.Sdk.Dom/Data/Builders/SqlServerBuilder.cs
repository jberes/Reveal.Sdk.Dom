using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public class SqlServerBuilder
    {
        readonly DataSource _dataSource = new DataSource() { Provider = DataSourceProviders.SqlServer }; //data source
        readonly DataSourceItem _dataSourceItem = new DataSourceItem(); //data source item that points to the data source

        public SqlServerBuilder(string host, string database, string table)
        {
            _dataSourceItem.DataSource = _dataSource;
            _dataSourceItem.DataSourceId = _dataSource.Id;

            SetHost(host);
            SetDatabase(database);
            SetTable(table);
            SetSchema("dbo");
        }

        public SqlServerBuilder SetDatabase(string database)
        {
            _dataSource.Properties.SetItem("Database", database);
            _dataSourceItem.Properties.SetItem("Database", database);
            return this;
        }

        public SqlServerBuilder SetFields(IEnumerable<IField> fields)
        {
            _dataSourceItem.Fields.Clear();
            _dataSourceItem.Fields.AddRange(fields);
            return this;
        }

        public SqlServerBuilder SetHost(string host)
        {
            _dataSource.Properties.SetItem("Host", host);
            return this;
        }

        public SqlServerBuilder SetSchema(string schema)
        {
            _dataSourceItem.Properties.SetItem("Schema", schema);
            return this;
        }

        public SqlServerBuilder SetTable(string table)
        {
            _dataSourceItem.Properties.SetItem("Table", table);
            return this;
        }

        public SqlServerBuilder SetTitle(string title)
        {
            _dataSource.Title = title;
            _dataSourceItem.Title = title;
            return this;
        }

        public SqlServerBuilder SetSubtitle(string subtitle)
        {
            _dataSource.Subtitle = subtitle;
            _dataSourceItem.Subtitle = subtitle;
            return this;
        }

        public DataSourceItem Build()
        {
            if (_dataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item. Call the SetFields method and provide the fields.");

            return _dataSourceItem;
        }
    }
}
