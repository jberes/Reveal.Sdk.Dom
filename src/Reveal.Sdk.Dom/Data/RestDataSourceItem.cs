using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Data
{
    public class RestDataSourceItem : DataSourceItem
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
            base(title, null)
        {
            _dataSource = dataSource ?? new DataSource();
            InitializeResourceItem(DataSourceProvider.REST, title);
            UpdateResourceItemDataSource(_dataSource);
        }

        public bool IsAnonymous
        {
            get { return ResourceItemDataSource.Properties.GetValue<bool>("_rpUseAnonymousAuthentication"); }
            set { ResourceItemDataSource.Properties.SetItem("_rpUseAnonymousAuthentication", value); }
        }

        public string Uri 
        { 
            get { return ResourceItem.Properties.GetValue<string>("Url"); }
            set 
            {
                ResourceItem.Properties.SetItem("Url", value);
                ResourceItemDataSource.Properties.SetItem("Url", value);
            } 
        }

        public void AddHeader(HeaderType headerType, string value)
        {
            var propertyKey = "Headers";

            var headerValue = $"{AddDashesToEnumName(headerType.ToString())}={value}";

            if (!ResourceItemDataSource.Properties.ContainsKey(propertyKey))
            {
                ResourceItemDataSource.Properties.Add(propertyKey, new List<string> { headerValue });
            }
            else
            {
                var headers = (List<string>)ResourceItemDataSource.Properties[propertyKey];
                headers.Add(headerValue);
            }
        }

        public void UseCsv()
        {
            ClearJsonConfig();
            UpdateDataSourceId(DataSourceIds.CSV);
            DataSource.Provider = DataSourceProvider.CSV;
            ResourceItemDataSource.Properties.SetItem("Result-Type", ".csv");
        }

        public void UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx)
        {
            ClearJsonConfig();
            UpdateDataSourceId(DataSourceIds.Excel);
            DataSource.Provider = DataSourceProvider.MicrosoftExcel;

            var fileExt = fileType == ExcelFileType.Xlsx ? ".xlsx" : ".xls";
            ResourceItemDataSource.Properties.SetItem("Result-Type", fileExt);

            if (sheet != null)
                Properties.SetItem("Sheet", sheet);
        }

        protected override void InitializeDataSource(DataSource dataSource, string title)
        {
            base.InitializeDataSource(dataSource, title);
            UpdateDataSourceId(DataSourceIds.JSON);
            DataSource.Provider = DataSourceProvider.JSON;
        }

        protected override void OnFieldsPropertyChanged(List<IField> fields)
        {
            Parameters.Add("config", BuildConfig(fields));
        }

        //todo: this may need to go on the base class. wait until more data source items are created
        private void UpdateResourceItemDataSource(DataSource dataSource)
        {
            ResourceItemDataSource.Id = dataSource.Id;
            ResourceItemDataSource.Title = dataSource.Title ?? ResourceItem.Title;
            ResourceItemDataSource.Subtitle = dataSource.Subtitle ?? ResourceItem.Subtitle;
            ResourceItem.DataSourceId = ResourceItemDataSource.Id;
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

        void ClearJsonConfig()
        {
            if (Parameters.ContainsKey("config"))
                Parameters.Remove("config");
        }

        string AddDashesToEnumName(string name)
        {
            return string.Concat(name.Select(x => char.IsUpper(x) ? "-" + x : x.ToString())).TrimStart('-');
        }
    }
}
