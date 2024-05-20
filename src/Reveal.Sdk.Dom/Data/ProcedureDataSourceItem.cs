using Newtonsoft.Json;

namespace Reveal.Sdk.Dom.Data
{
    public abstract class ProcedureDataSourceItem : DatabaseDataSourceItem
    {
        public ProcedureDataSourceItem(string title, DataSource dataSource) :
            base(title, dataSource)
        { }

        [JsonIgnore]
        public string Procedure { get; set; }

        [JsonIgnore]
        public string ProcedureParameters { get; set; }
    }
}
