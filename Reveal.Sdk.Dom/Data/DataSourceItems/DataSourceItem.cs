using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations.Primitives;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reveal.Sdk.Dom.Data
{
    public class DataSourceItem : SchemaType
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }

        [JsonPropertyName("Description")]
        public string Subtitle { get; set; }
        public string DataSourceId { get; set; }
        public bool HasTabularData { get; set; }
        public bool HasAsset { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        public DataSourceItem ResourceItem { get; set; }

        [JsonIgnore]
        public List<Field> Fields { get; internal set; } = new List<Field>();

        /// <summary>
        /// The data source for the current DataSourceItem
        /// </summary>
        internal DataSource DataSource { get; set; }

        /// <summary>
        /// The data source for the ResourceItem
        /// </summary>
        internal DataSource ResourceItemDataSource { get; set; }

        public DataSourceItem()
        {
            SchemaTypeName = SchemaTypeNames.DataSourceItemType;
        }
    }
}
