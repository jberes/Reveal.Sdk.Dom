namespace Reveal.Sdk.Dom.Data.Builders
{
    public class DSIBuilder
    {
        public ExcelBuilder UseExcel(string uri)
        {
            return new ExcelBuilder(uri);
        }
    }
}
