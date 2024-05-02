namespace Reveal.Sdk.Dom.Visualizations
{
    public static class IDataDefinitionExtensions
    {
        public static TabularDataDefinition AsTabular(this IDataDefinition dataDefinition)
        {
            return dataDefinition as TabularDataDefinition;
        }

        public static XmlaDataDefinition AsXmla(this IDataDefinition dataDefinition)
        {
            return dataDefinition as XmlaDataDefinition;
        }
    }
}
