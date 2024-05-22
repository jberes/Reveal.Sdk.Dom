using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    //todo: we may need a base class named LocalFileDataSourceItem which has shared properties between different file types
    //todo: need to add more Excel specific properties
    public class ExcelFileDataSourceItem : DataSourceItem
    {
        public ExcelFileDataSourceItem(string title) :
            this(title, new DataSource())
        { }

        public ExcelFileDataSourceItem(string title, string path) :
            this(title, path, null)
        { }

        public ExcelFileDataSourceItem(string title, string path, string sheet) :
            this(title, new DataSource())
        {
            Path = path;
            Sheet = sheet;
        }

        public ExcelFileDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        {
            InitializeResourceItem(title);
        }

        [JsonIgnore]
        public string Path
        {
            get { return ResourceItem.Properties.GetValue<string>("URI"); }
            set { ResourceItem.Properties.SetItem("URI", $"local:{value}"); }
        }

        [JsonIgnore]
        public string Sheet
        {
            get { return Properties.GetValue<string>("Sheet"); }
            set { Properties.SetItem("Sheet", value); }
        }

        protected override void InitializeDataSource(DataSource dataSource, string title)
        {
            base.InitializeDataSource(dataSource, title);
            UpdateDataSourceId(DataSourceIds.Excel);
            DataSource.Provider = DataSourceProvider.MicrosoftExcel;
        }

        private void InitializeResourceItem(string title)
        {
            ResourceItemDataSource = new DataSource { Provider = DataSourceProvider.LocalFile, Id = DataSourceIds.LOCALFILE };
            ResourceItem = new DataSourceItem
            {
                DataSource = ResourceItemDataSource,
                DataSourceId = ResourceItemDataSource.Id,
                Title = title
            };

            ResourceItemDataSource = ResourceItemDataSource;
            ResourceItem = ResourceItem;
        }

    }
}
