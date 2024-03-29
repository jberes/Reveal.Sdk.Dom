using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Data
{
    public sealed class RestServiceBuilder
    {
        readonly DataSource _dataSource = new DataSource() { Id = DataSourceIds.JSON, Provider = DataSourceProvider.JSON }; //data source
        readonly DataSourceItem _dataSourceItem = new DataSourceItem(); //data source item that points to the data source
        readonly DataSource _resourceItemDataSource = new DataSource() { Provider = DataSourceProvider.REST }; //rest data source
        readonly DataSourceItem _resourceItem = new DataSourceItem(); //resource item that points to the rest data source

        public RestServiceBuilder(string uri)
        {
            _dataSourceItem.DataSource = _dataSource;
            _dataSourceItem.DataSourceId = _dataSource.Id;
            _dataSourceItem.HasTabularData = true;

            _resourceItemDataSource.Properties.Add("_rpUseAnonymousAuthentication", true);
            _resourceItemDataSource.Properties.Add("Url", uri);
            _resourceItemDataSource.Properties.Add("Method", "GET");
            _resourceItemDataSource.Properties.Add("Result-Type", ".json");

            _dataSourceItem.ResourceItemDataSource = _resourceItemDataSource;
            _resourceItem.DataSourceId = _resourceItemDataSource.Id;

            _resourceItem.Properties.Add("Url", uri);
            _dataSourceItem.ResourceItem = _resourceItem;
        }


        public RestServiceBuilder IsAnonymous(bool isAnonymous)
        {
            _resourceItemDataSource.Properties["_rpUseAnonymousAuthentication"] = isAnonymous;
            return this;
        }

        public RestServiceBuilder SetFields(IEnumerable<IField> fields)
        {
            _dataSourceItem.Fields.Clear();
            _dataSourceItem.Fields.AddRange(fields);

            _dataSourceItem.Parameters.Add("config", BuildConfig(fields));

            return this;
        }

        public RestServiceBuilder SetTitle(string title)
        {
            _dataSourceItem.Title = title;
            _resourceItem.Title = title;
            _resourceItemDataSource.Title = title;
            return this;
        }

        public RestServiceBuilder SetSubtitle(string subtitle)
        {
            _dataSourceItem.Subtitle = subtitle;
            return this;
        }

        public DataSourceItem Build()
        {
            if (_dataSourceItem.Fields.Count == 0)
                throw new ArgumentException("You must provide the field definitions for the data source item. Call the SetFields method and provide the fields.");

            return _dataSourceItem;
        }

        public RestServiceBuilder AddHeader(HeaderType headerType, string value)
        {
            var propertyKey = "Headers";

            var headerValue = $"{AddDashesToEnumName(headerType.ToString())}={value}";

            if (!_resourceItemDataSource.Properties.ContainsKey(propertyKey))
            {
                _resourceItemDataSource.Properties.Add(propertyKey, new List<string> { headerValue });
            }
            else
            {
                var headers = (List<string>)_resourceItemDataSource.Properties[propertyKey];
                headers.Add(headerValue);
            }

            return this;
        }

        public RestServiceBuilder UseCsv()
        {
            ClearJsonConfig();

            _dataSource.Id = DataSourceIds.CSV;
            _dataSource.Provider = DataSourceProvider.CSV;
            _resourceItemDataSource.Properties["Result-Type"] = ".csv";

            _dataSourceItem.DataSourceId = _dataSource.Id;

            return this;
        }

        public RestServiceBuilder UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx)
        {
            ClearJsonConfig();

            _dataSource.Id = DataSourceIds.Excel;
            _dataSource.Provider = DataSourceProvider.MicrosoftExcel;

            var fileExt = fileType == ExcelFileType.Xlsx ? ".xlsx" : ".xls";
            _resourceItemDataSource.Properties["Result-Type"] = fileExt;

            if (sheet != null)
            {
                _dataSourceItem.Subtitle = sheet;

                if (_dataSourceItem.Properties.ContainsKey("Sheet"))
                    _dataSourceItem.Properties["Sheet"] = sheet;
                else
                    _dataSourceItem.Properties.Add("Sheet", sheet);
            }

            _dataSourceItem.DataSourceId = _dataSource.Id;

            return this;
        }

        Dictionary<string, object> BuildConfig(IEnumerable<IField> fields)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            List<ColumnConfig> columnConfigs = new List<ColumnConfig>();
            foreach (var field in fields)
            {
                if (field == null)
                    continue;

                var columnConfig = new ColumnConfig
                {
                    Key = field.FieldName
                };


                int type = ((IFieldDataType)field).DataType switch
                {
                    DataType.Number => 1,
                    DataType.Date => 2,
                    DataType.DateTime => 3,
                    DataType.Time => 4,
                    _ => 0
                };

                columnConfig.Type = type;                
                columnConfigs.Add(columnConfig);
            }

            config.Add("iterationDepth", 0);
            config.Add("columnsConfig", columnConfigs);
            return config;
        }

        void ClearJsonConfig()
        {
            if (_dataSourceItem.Parameters.ContainsKey("config"))
                _dataSourceItem.Parameters.Remove("config");
        }

        string AddDashesToEnumName(string name)
        {
            return string.Concat(name.Select(x => char.IsUpper(x) ? "-" + x : x.ToString())).TrimStart('-');
        }
    }
}
