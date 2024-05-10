namespace Reveal.Sdk.Dom.Data
{
    public static class ITabularDataFactoryExtensions
    {

    }

    public static class IDataSourceBuilderExtensions
    {
        public static T As<T>(this IDataSourceBuilder builder) where T : class, IDataSourceBuilder
        {
            return builder as T;
        }
    }
}
