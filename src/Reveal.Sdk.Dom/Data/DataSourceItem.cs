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
        public DataSourceItem(string title, DataSource dataSource) : this()
        {
            InitializeDataSource(dataSource, title);
            InitializeDataSourceItem(title);
        }

        public DataSourceItem()
        {
            SchemaTypeName = SchemaTypeNames.DataSourceItemType;
        }

        private string _id = Guid.NewGuid().ToString();
        public string Id
        {
            get => _id;
            set
            {
                _id = string.IsNullOrEmpty(value) ? Guid.NewGuid().ToString() : value;
                if (ResourceItem != null) //if we are dealing with a resource item, set the id on the resource item to be the same
                    ResourceItem.Id = _id;
            }
        }

        public string Title { get; set; }

        private string _subtitle;
        public string Subtitle
        {
            get => _subtitle;
            set
            {
                _subtitle = value;
                if (ResourceItem != null)
                    ResourceItem.Subtitle = value;
            }
        }

        [JsonProperty]
        internal string DataSourceId { get; set; }

        [JsonProperty]
        internal bool HasTabularData { get; set; } = true;

        [JsonProperty]
        internal bool HasAsset { get; set; }

        [JsonProperty]
        internal Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        [JsonProperty]
        internal Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();

        [JsonProperty]
        internal DataSourceItem ResourceItem { get; set; }

        private List<IField> _fields = new List<IField>();
        [JsonIgnore]
        public List<IField> Fields 
        { 
            get => _fields; 
            set
            { 
                _fields = value;
                OnFieldsPropertyChanged(_fields);
            } 
        }

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

        protected virtual void InitializeDataSource(DataSource dataSource, string title)
        {
            DataSource = dataSource ?? new DataSource();
            if (string.IsNullOrEmpty(DataSource.Title))
                DataSource.Title = title;

            DataSourceId = DataSource.Id;
        }

        protected virtual void InitializeDataSourceItem(string title)
        {
            Title = title;
        }

        protected virtual void InitializeResourceItem(DataSourceProvider resourceItemDataSourceProvider, string title)
        {
            ResourceItemDataSource = new DataSource { Provider = resourceItemDataSourceProvider };
            ResourceItem = new DataSourceItem
            {
                DataSource = ResourceItemDataSource,
                DataSourceId = ResourceItemDataSource.Id,
                Title = title
            };

            ResourceItemDataSource = ResourceItemDataSource;
            ResourceItem = ResourceItem;
        }

        protected virtual void OnFieldsPropertyChanged(List<IField> fields) {  }

        protected virtual void UpdateDataSourceId(string id)
        {
            DataSource.Id = id;
            DataSourceId = id;
        }
    }
}
