using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Data
{
    public class RestDataSourceItem : WebServiceDataSourceItem
    {
        DataSource _dataSource;

        public RestDataSourceItem(string title) :
            this(title, new DataSource())
        { }

        public RestDataSourceItem(string title, string uri) :
            this(title, uri, new DataSource())
        { }

        public RestDataSourceItem(string title, string uri, DataSource dataSource) :
            this(title, dataSource)
        {
            Uri = uri;
        }

        public RestDataSourceItem(string title, DataSource dataSource) :
            base(title, new JsonDataSource())
        {
            _dataSource = dataSource ?? new DataSource();
            InitializeResourceItem(title);
            UpdateResourceItemDataSource(_dataSource);
        }

        protected void InitializeResourceItem(string title)
        {
            ResourceItemDataSource = new DataSource { Provider = DataSourceProvider.REST };
            ResourceItem = new DataSourceItem
            {
                DataSource = ResourceItemDataSource,
                DataSourceId = ResourceItemDataSource.Id,
                Title = title
            };

            ResourceItemDataSource = ResourceItemDataSource;
            ResourceItem = ResourceItem;
        }

        protected override void OnFieldsPropertyChanged(List<IField> fields)
        {
            Parameters.Add("config", BuildConfig(fields));
        }

        private Dictionary<string, object> BuildConfig(IEnumerable<IField> fields)
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