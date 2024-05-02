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
        public bool HasTabularData { get; set; } = true;
        public bool HasAsset { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        public DataSourceItem ResourceItem { get; set; }

        [JsonIgnore]
        internal List<IField> Fields { get; set; } = new List<IField>();

        /// <summary>
        /// The data source for the current DataSourceItem. This is set internally by a data source builder and is only used during the RdashDocumentValidator process.
        /// If this is null, then the DataSourceItem was manually added to the document and the DataSourceId property should be used to find the data source.
        /// </summary>
        [JsonIgnore]
        internal DataSource DataSource { get; set; }

        /// <summary>
        /// The data source for the ResourceItem. This is set internally by a data source builder and is only used during the RdashDocumentValidator process.
        /// If this is null, then the ResourceItem was manually added to the document and the ResourceItem.DataSourceId property should be used to find the data source.
        /// </summary>
        [JsonIgnore]
        internal DataSource ResourceItemDataSource { get; set; }

        public DataSourceItem()
        {
            SchemaTypeName = SchemaTypeNames.DataSourceItemType;
        }
    }
}
