namespace Reveal.Sdk.Dom.Data
{
    public interface IRestBuilder : IDataSourceBuilder
    {
        IRestBuilder AddHeader(HeaderType headerType, string value);
        IRestBuilder SetUrl(string url);
        IRestBuilder SetMethod(string method);
        IRestBuilder SetAnonymous(bool isAnonymous);
    }

}
