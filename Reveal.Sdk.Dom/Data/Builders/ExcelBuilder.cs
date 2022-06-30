using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data.Builders
{
    public class ExcelBuilder
    {
        ExcelDataSource _dataSource = new ExcelDataSource();
        DataSourceItem _dataSourceItem = new DataSourceItem();
        WebResourceDataSource _resourceItemDataSource = new WebResourceDataSource();
        DataSourceItem _resourceItem = new DataSourceItem();

        public ExcelBuilder(string uri)
        {
            _dataSourceItem.DataSource = _dataSource;
            _dataSourceItem.DataSourceId = _dataSource.Id;

            _resourceItemDataSource.Url = uri;
            _dataSourceItem.ResourceItemDataSource = _resourceItemDataSource;
           
            _resourceItem.DataSourceId = _resourceItemDataSource.Id;
            _resourceItem.Properties.Add("Url", uri);
            _dataSourceItem.ResourceItem = _resourceItem;
        }

        public ExcelBuilder IsAnonymous(bool isAnonymous)
        {
            _resourceItemDataSource.UseAnonymousAuthentication = isAnonymous;
            return this;
        }

        public ExcelBuilder SetFields(IEnumerable<Field> fields)
        {
           _dataSourceItem.Fields.Clear();
           _dataSourceItem.Fields.AddRange(fields);
            return this;
        }

        public ExcelBuilder SetTitle(string title)
        {
            return SetTitle(title, null);
        }

        public ExcelBuilder SetTitle(string title, string subtitle)
        {
            _dataSourceItem.Title = title;
            _dataSourceItem.Subtitle = subtitle;

            _resourceItem.Title = title;
            _resourceItemDataSource.Title = title;

            return this;
        }

        public ExcelBuilder UseSheet(string sheet)
        {
            _dataSourceItem.Subtitle = sheet;

            if (_dataSourceItem.Properties.ContainsKey("Sheet"))
                _dataSourceItem.Properties["Sheet"] = sheet;
            else
                _dataSourceItem.Properties.Add("Sheet", sheet);
            
            return this;
        }

        public DataSourceItem Build()
        {
            if (_dataSourceItem.Fields == null || _dataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item.");

            return _dataSourceItem;
        }
    }
}
