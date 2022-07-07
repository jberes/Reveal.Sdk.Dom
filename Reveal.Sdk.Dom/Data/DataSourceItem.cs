using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceItem : SchemaType
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string DataSourceId { get; set; }
        public bool HasTabularData { get; set; }
        public bool HasAsset { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        public DataSourceItem ResourceItem { get; set; }

        [JsonIgnore]
        public List<Field> Fields { get; internal set; } = new List<Field>();

        [JsonIgnore]
        /// <summary>
        /// The data source for the current DataSourceItem
        /// </summary>
        public DataSource DataSource { get; internal set; }

        [JsonIgnore]
        /// <summary>
        /// The data source for the ResourceItem
        /// </summary>
        public DataSource ResourceItemDataSource { get; internal set; }

        public DataSourceItem()
        {
            SchemaTypeName = SchemaTypeNames.DataSourceItemType;
        }
    }
}
