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
            Initialize(dataSource ?? new DataSource(), title);
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
        private DataSource _dataSource;

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
        internal DataSource DataSource
        {
            get => _dataSource;
            set
            {
                _dataSource = value;
                DataSourceId = _dataSource?.Id;
            }
        }

        /// <summary>
        /// The data source for the ResourceItem. This is set internally by a data source builder and is only used during the RdashDocumentValidator process.
        /// If this is null, then the ResourceItem was manually added to the document and the ResourceItem.DataSourceId property should be used to find the data source.
        /// </summary>
        [JsonIgnore]
        internal DataSource ResourceItemDataSource { get; set; }

        private void Initialize(DataSource dataSource, string title)
        {
            DataSource = CreateDataSourceInstance(dataSource);
            InitializeDataSource(DataSource, title);
            InitializeDataSourceItem(title);
        }

        protected virtual void InitializeDataSource(DataSource dataSource, string title)
        {
            DataSource = dataSource;
            DataSourceId = DataSource.Id;

            if (string.IsNullOrEmpty(DataSource.Title))
                DataSource.Title = title;
        }

        protected virtual DataSource CreateDataSourceInstance(DataSource dataSource)
        {
            return dataSource;
        }

        protected T Create<T>(DataSource dataSource) where T : DataSource, new()
        {
            if (dataSource is T specificDataSource)
                return specificDataSource;

            return new T
            {
                Id = dataSource.Id,
                Title = dataSource.Title,
                Subtitle = dataSource.Subtitle
            };
        }

        protected virtual void InitializeDataSourceItem(string title)
        {
            Title = title;
        }

        protected virtual void OnFieldsPropertyChanged(List<IField> fields) { }
    }
}
