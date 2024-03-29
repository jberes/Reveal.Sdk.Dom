using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Data
{
    public class RestBuilder : DataSourceBuilder, IRestBuilder
    {
        readonly DataSource _resourceItemDataSource = new DataSource() { Provider = DataSourceProvider.REST }; //rest data source
        readonly DataSourceItem _resourceItem = new DataSourceItem(); //resource item that points to the rest data source

        public RestBuilder(string title, string subtitle) : 
            base(DataSourceProvider.JSON, title, subtitle)
        {
            DataSourceItem.HasTabularData = true;
            DataSourceItem.ResourceItemDataSource = _resourceItemDataSource;
            _resourceItem.DataSourceId = _resourceItemDataSource.Id;
            DataSourceItem.ResourceItem = _resourceItem;

            SetAnonymous(true);
            SetMethod("GET");
            _resourceItemDataSource.Properties.Add("Result-Type", ".json");
        }

        public IRestBuilder AddHeader(HeaderType headerType, string value)
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

        public IRestBuilder SetAnonymous(bool isAnonymous)
        {
            _resourceItemDataSource.Properties["_rpUseAnonymousAuthentication"] = isAnonymous;
            return this;
        }

        public IRestBuilder SetMethod(string method)
        {
            _resourceItemDataSource.Properties.Add("Method", method);
            return this;
        }

        public IRestBuilder SetUrl(string url)
        {
            _resourceItemDataSource.Properties.Add("Url", url);
            return this;
        }

        public override IDataSourceBuilder SetFields(IEnumerable<IField> fields)
        {
            DataSourceItem.Parameters.Add("config", BuildConfig(fields));
            return base.SetFields(fields);
        }

        string AddDashesToEnumName(string name)
        {
            return string.Concat(name.Select(x => char.IsUpper(x) ? "-" + x : x.ToString())).TrimStart('-');
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
    }

}
