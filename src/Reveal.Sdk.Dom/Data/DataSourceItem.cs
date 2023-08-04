using Newtonsoft.Json;
using Reveal.Sdk.Dom.Core;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;

namespace Reveal.Sdk.Dom.Data
{
    public sealed class DataSourceItem : SchemaType
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
        public List<IField> Fields { get; internal set; } = new List<IField>();

        /// <summary>
        /// The data source for the current DataSourceItem. This is only used during the RdashDocumentValidator process.
        /// </summary>
        [JsonIgnore]
        internal DataSource DataSource { get; set; }

        /// <summary>
        /// The data source for the ResourceItem. This is only used during the RdashDocumentValidator process.
        /// </summary>
        [JsonIgnore]
        internal DataSource ResourceItemDataSource { get; set; }

        public DataSourceItem()
        {
            SchemaTypeName = SchemaTypeNames.DataSourceItemType;
        }
    }
}
