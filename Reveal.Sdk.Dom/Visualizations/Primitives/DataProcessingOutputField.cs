using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Visualizations.Primitives
{
    public class DataProcessingOutputField
    {
        public string OutputColumnName { get; set; }
        public string ResultColumnName { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DataType DataType { get; set; }
        public string FeatureName { get; set; }
        public bool IsBoolean { get; set; }
        public string ReferenceColumn { get; set; }

        public DataProcessingOutputField()
        {
            DataType = DataType.String;
        }
    }
}
