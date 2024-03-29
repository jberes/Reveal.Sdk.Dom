using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Data
{
    public class RemoteFileBuilder : DataSourceBuilder, IRemoteFileBuilder
    {
        readonly DataSource _resourceItemDataSource = new DataSource() { Provider = DataSourceProvider.WebService }; //data source
        readonly DataSourceItem _resourceItem = new DataSourceItem(); //resource item that points to the data source

        public RemoteFileBuilder(string title, string subtitle) : base(DataSourceProvider.WebService, title, subtitle)
        {
            DataSourceItem.ResourceItemDataSource = _resourceItemDataSource;
            _resourceItem.DataSourceId = _resourceItemDataSource.Id;
            DataSourceItem.ResourceItem = _resourceItem;

            SetAnonymous(true);
        }

        public IRemoteFileBuilder SetAnonymous(bool isAnonymous)
        {
            _resourceItemDataSource.Properties["_rpUseAnonymousAuthentication"] = isAnonymous;
            return this;
        }

        public IRemoteFileBuilder SetUrl(string url)
        {
            _resourceItemDataSource.Properties.Add("Url", url);
            _resourceItem.Properties.Add("Url", url);
            return this;
        }

        public IRemoteFileBuilder UseCsv()
        {
            DataSource.Id = DataSourceIds.CSV;
            DataSource.Provider = DataSourceProvider.CSV;
            _resourceItemDataSource.Properties["Result-Type"] = ".csv";
            DataSourceItem.DataSourceId = DataSource.Id;
            return this;
        }

        public IRemoteFileBuilder UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx)
        {
            DataSource.Id = DataSourceIds.Excel;
            DataSource.Provider = DataSourceProvider.MicrosoftExcel;

            if (sheet != null)
            {
                DataSourceItem.Subtitle = sheet;

                if (DataSourceItem.Properties.ContainsKey("Sheet"))
                    DataSourceItem.Properties["Sheet"] = sheet;
                else
                    DataSourceItem.Properties.Add("Sheet", sheet);
            }

            DataSourceItem.DataSourceId = DataSource.Id;

            return this;
        }

    }

    public interface IRemoteFileBuilder : IDataSourceBuilder
    {
        IRemoteFileBuilder UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx);
        IRemoteFileBuilder UseCsv();
    }
}
