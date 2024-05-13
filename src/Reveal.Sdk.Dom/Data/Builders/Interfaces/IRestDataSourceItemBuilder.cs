namespace Reveal.Sdk.Dom.Data
{
    public interface IRestDataSourceItemBuilder : IDataSourceItemBuilder
    {
        IRestDataSourceItemBuilder AddHeader(HeaderType headerType, string value);
        IRestDataSourceItemBuilder IsAnonymous(bool isAnonymous);
        IRestDataSourceItemBuilder UseCsv();
        IRestDataSourceItemBuilder UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx);
        IRestDataSourceItemBuilder Uri(string uri);
    }
}
