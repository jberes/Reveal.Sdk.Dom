using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Data
{
    internal class ExcelDataSource : DataSource
    {
        public ExcelDataSource()
        {
            Id = DataSourceIds.Excel;
            Provider = DataSourceProvider.MicrosoftExcel;
        }
    }
}
