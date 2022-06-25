using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Serialization.Converters;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    [JsonConverter(typeof(SummarizationFieldConverter))]
    public class SummarizationField : SchemaType
    {
        public string FieldName { get; set; }
        public string Description { get; set; }

        internal SummarizationField() { }

        public SummarizationField(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
