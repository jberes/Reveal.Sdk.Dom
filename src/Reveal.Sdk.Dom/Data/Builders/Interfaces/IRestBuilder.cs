namespace Reveal.Sdk.Dom.Data
{
    public interface IRestBuilder : IDataSourceBuilder
    {
        IRestBuilder AddHeader(HeaderType headerType, string value);
        IRestBuilder IsAnonymous(bool isAnonymous);
        IRestBuilder UseCsv();
        IRestBuilder UseExcel(string sheet = null, ExcelFileType fileType = ExcelFileType.Xlsx);
        IRestBuilder Uri(string uri);
    }
}
