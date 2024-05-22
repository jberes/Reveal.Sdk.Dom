using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core.Extensions;

namespace Reveal.Sdk.Dom.Data
{
    //todo: we may need a base class named LocalFileDataSourceItem which has shared properties between different file types
    //todo: need to add more Excel specific properties
    public class ExcelFileDataSourceItem : DataSourceItem
    {
        public ExcelFileDataSourceItem(string title) :
            this(title, new ExcelDataSource())
        { }

        public ExcelFileDataSourceItem(string title, string path) :
            this(title, path, null)
        { }

        public ExcelFileDataSourceItem(string title, string path, string sheet) :
            this(title, new ExcelDataSource())
        {
            Path = path;
            Sheet = sheet;
        }

        internal ExcelFileDataSourceItem(string title, DataSource dataSource) :
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

        protected override DataSource CreateDataSourceInstance(DataSource dataSource)
        {
            if (dataSource is ExcelDataSource)
                return dataSource;

            return new ExcelDataSource()
            {
                Title = dataSource.Title,
                Subtitle = dataSource.Subtitle,
            };
        }

        private void InitializeResourceItem(string title)
        {
            ResourceItemDataSource = new LocalFileDataSource();
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
