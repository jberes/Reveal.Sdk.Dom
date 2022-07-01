namespace Reveal.Sdk.Dom.Data.Builders
{
    public class DSIBuilder
    {
        public ExcelBuilder UseExcel(ExcelDataSource excelDataSource)
        {
            return new ExcelBuilder(excelDataSource);
        }

        public ExcelBuilder UseExcel(string uri)
        {
            return new ExcelBuilder(uri);
        }
    }
}
