namespace Reveal.Sdk.Dom.Filters
{
    public sealed class VisualizationFilter
    {
        public string FieldName { get; set; }

        public VisualizationFilter() { }

        public VisualizationFilter(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
