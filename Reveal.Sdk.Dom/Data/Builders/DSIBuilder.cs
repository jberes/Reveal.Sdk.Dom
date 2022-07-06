namespace Reveal.Sdk.Dom.Data
{
    //todo: think of better name
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
