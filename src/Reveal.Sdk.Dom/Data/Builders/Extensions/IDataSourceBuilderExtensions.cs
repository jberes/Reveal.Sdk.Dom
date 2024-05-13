namespace Reveal.Sdk.Dom.Data
{
    public static class IDataSourceBuilderExtensions
    {
        public static T As<T>(this IDataSourceItemBuilder builder) where T : class, IDataSourceItemBuilder
        {
            return builder as T;
        }
    }
}
