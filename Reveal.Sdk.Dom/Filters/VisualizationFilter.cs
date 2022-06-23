namespace Reveal.Sdk.Dom.Filters
{
    public class VisualizationFilter
    {
        public string FieldName { get; set; }

        public VisualizationFilter() { }

        public VisualizationFilter(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
