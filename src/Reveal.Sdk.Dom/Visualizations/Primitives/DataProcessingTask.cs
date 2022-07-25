using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Visualizations
{
    internal sealed class DataProcessingTask
    {
        public List<DataProcessingInputField> InputFields { get; set; }
        public List<DataProcessingOutputField> OutputFields { get; set; }
        public Dictionary<string, object> Parameters { get; set; }

        public DataProcessingTask()
        {
            InputFields = new List<DataProcessingInputField>();
            OutputFields = new List<DataProcessingOutputField>();
            Parameters = new Dictionary<string, object>();
        }
    }
}
