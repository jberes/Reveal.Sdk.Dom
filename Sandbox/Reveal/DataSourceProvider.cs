using Reveal.Sdk;
using System.Threading.Tasks;

namespace Sandbox.RevealBI
{
    internal class DataSourceProvider : IRVDataSourceProvider
    {
        public Task<RVDataSourceItem> ChangeDataSourceItemAsync(RVDataSourceItem dataSourceItem)
        {

            if (dataSourceItem is RVExcelDataSourceItem excelDataSourceItem)
            {
                var resourceItem = excelDataSourceItem.ResourceItem as RVDataSourceItem;
                if (resourceItem.Title == "Excel Data Source")
                {
                    var localItem = new RVLocalFileDataSourceItem();
                    localItem.Uri = "local:/Samples.xlsx";
                    localItem.Title = resourceItem.Title;

                    excelDataSourceItem.ResourceItem = localItem;
                }
            }

            return Task.FromResult(dataSourceItem);
        }
    }
}