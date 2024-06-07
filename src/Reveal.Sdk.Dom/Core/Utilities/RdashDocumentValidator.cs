using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Core.Utilities
{
    internal static class RdashDocumentValidator
    {
        internal static void Validate(RdashDocument document)
        {
            FixVisualizations(document);
        }

        static void FixVisualizations(RdashDocument document)
        {
            Dictionary<string, DataSource> dataSources = new Dictionary<string, DataSource>();

            foreach (var visualization in document.Visualizations)
            {
                if (visualization.DataDefinition is TabularDataDefinition tdd)
                {
                    if (tdd.DataSourceItem == null)
                        throw new Exception($"DataSourceItem for visualization {visualization.Title} is null.");

                    FixFields(tdd);
                    FixJoinedTables(tdd);
                    FixDataSources(document, tdd.DataSourceItem, dataSources);
                }
                //todo: handle XmlaDataDefinition
            }

            UpdateDocumentDataSources(document, dataSources);
        }

        private static void FixFields(TabularDataDefinition tdd)
        {
            if (tdd.DataSourceItem.Fields?.Count != 0)
            {
                // Create a HashSet to track added field names
                HashSet<string> fieldNames = new HashSet<string>(tdd.Fields.Select(f => f.FieldName));

                foreach (var field in tdd.DataSourceItem.Fields.Clone())
                {
                    if (field == null)
                        throw new Exception($"Field for DataSourceItem {tdd.DataSourceItem.Title} is null.");

                    //prevent adding duplicate fields
                    if (!fieldNames.Contains(field.FieldName))
                    {
                        tdd.Fields.Add(field);
                        fieldNames.Add(field.FieldName);
                    }
                }
            }

            if (tdd.Fields?.Count == 0)
                throw new Exception($"Fields for DataSourceItem {tdd.DataSourceItem.Title} is null.");
        }

        static void FixJoinedTables(TabularDataDefinition tdd)
        {
            if (tdd.DataSourceItem.JoinTables != null)
            {
                tdd.JoinTables.AddRange(tdd.DataSourceItem.JoinTables.Clone());
            }
        }

        static void FixDataSources(RdashDocument document, DataSourceItem dataSourceItem, Dictionary<string, DataSource> dataSources)
        {
            if (dataSourceItem.DataSource != null)
            {
                if (!dataSources.ContainsKey(dataSourceItem.DataSource.Id))
                    dataSources.Add(dataSourceItem.DataSource.Id, dataSourceItem.DataSource);

                if (dataSourceItem.ResourceItemDataSource != null && !dataSources.ContainsKey(dataSourceItem.ResourceItemDataSource.Id))
                    dataSources.Add(dataSourceItem.ResourceItemDataSource.Id, dataSourceItem.ResourceItemDataSource);
            }
            else
            {
                ValidateManuallyAddedDataSourceItem(document, dataSourceItem);
            }
        }

        static void ValidateManuallyAddedDataSourceItem(RdashDocument document, DataSourceItem dsi)
        {
            var ds = document.DataSources?.FirstOrDefault(x => x.Id == dsi.DataSourceId);
            if (ds == null)
                throw new Exception($"Data source with id {dsi.DataSourceId} not found in the RdashDocument.DataSources collection.");

            if (dsi.ResourceItem != null)
            {
                var rds = document.DataSources?.FirstOrDefault(x => x.Id == dsi.ResourceItem.DataSourceId);
                if (rds == null)
                    throw new Exception($"ResourceItem with Data source id {dsi.ResourceItem.DataSourceId} not found in the RdashDocument.DataSources collection.");
            }
        }

        private static void UpdateDocumentDataSources(RdashDocument document, Dictionary<string, DataSource> dataSources)
        {
            var allDataSources = document.DataSources?.Union(dataSources.Values) ?? dataSources.Values;
            document.DataSources = allDataSources.ToList();
        }
    }
}
