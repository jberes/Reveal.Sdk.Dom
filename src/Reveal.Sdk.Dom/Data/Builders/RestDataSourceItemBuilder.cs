using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Data
{
    public class RestDataSourceItemBuilder : DataSourceResourceItemBuilder, IRestDataSourceItemBuilder
    {
        //bug: the url is required on the client or it won't work

        DataSource _dataSource;

        public RestDataSourceItemBuilder(string title) :
            this(new DataSource(), title)
        { }

        public RestDataSourceItemBuilder(DataSource dataSource, string title) :
            base(null, DataSourceProvider.JSON, DataSourceProvider.REST, title)
        {
            _dataSource = dataSource ?? new DataSource();
            DataSource.Id = DataSourceIds.JSON;
            DataSourceItem.DataSourceId = DataSource.Id;
            UpdateResourceItemDataSource(_dataSource);
        }

        public override IDataSourceItemBuilder Fields(IEnumerable<IField> fields)
        {
            DataSourceItem.Parameters.Add("config", BuildConfig(fields));
            return base.Fields(fields);
        }

        public IRestDataSourceItemBuilder AddHeader(HeaderType headerType, string value)
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

            return this;
        }

        public IRestDataSourceItemBuilder IsAnonymous(bool isAnonymous)
        {
            ResourceItemDataSource.Properties.SetItem("_rpUseAnonymousAuthentication", isAnonymous);
            return this;
        }

        public IRestDataSourceItemBuilder UseCsv()
        {
            ClearJsonConfig();
            UpdateDataSourceId(DataSourceIds.CSV);
            DataSource.Provider = DataSourceProvider.CSV;
            ResourceItemDataSource.Properties.SetItem("Result-Type", ".csv");
            return this;
        }

        public IRestDataSourceItemBuilder UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx)
        {
            ClearJsonConfig();
            UpdateDataSourceId(DataSourceIds.Excel);
            DataSource.Provider = DataSourceProvider.MicrosoftExcel;

            var fileExt = fileType == ExcelFileType.Xlsx ? ".xlsx" : ".xls";
            ResourceItemDataSource.Properties.SetItem("Result-Type", fileExt);

            if (sheet != null)
                DataSourceItem.Properties.SetItem("Sheet", sheet);

            return this;
        }

        public IRestDataSourceItemBuilder Uri(string uri)
        {
            ResourceItem.Properties.SetItem("Url", uri);
            ResourceItemDataSource.Properties.SetItem("Url", uri);
            return this;
        }

        public override IDataSourceItemBuilder Id(string id)
        {
            ResourceItem.Id = id;
            return this;
        }

        public override IDataSourceItemBuilder Subtitle(string subtitle)
        {
            base.Subtitle(subtitle);
            ResourceItem.Subtitle = subtitle;
            return this;
        }

        public override IDataSourceItemBuilder ConfigureDataSource(Action<DataSource> configureDataSource)
        {
            configureDataSource.Invoke(_dataSource);
            UpdateResourceItemDataSource(_dataSource);
            return this;
        }

        //todo: this may need to go on the base class. wait until more builders are created
        private void UpdateResourceItemDataSource(DataSource dataSource)
        {
            ResourceItemDataSource.Id = dataSource.Id;
            ResourceItemDataSource.Title = dataSource.Title ?? ResourceItem.Title;
            ResourceItemDataSource.Subtitle = dataSource.Subtitle ?? ResourceItem.Subtitle;
            ResourceItem.DataSourceId = ResourceItemDataSource.Id;
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
            if (DataSourceItem.Parameters.ContainsKey("config"))
                DataSourceItem.Parameters.Remove("config");
        }

        string AddDashesToEnumName(string name)
        {
            return string.Concat(name.Select(x => char.IsUpper(x) ? "-" + x : x.ToString())).TrimStart('-');
        }
    }
}
