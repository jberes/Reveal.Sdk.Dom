using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Core.Utilities
{
    internal static class RdashDocumentValidator
    {
        internal static void FixDocument(RdashDocument document)
        {
            FixDataSources(document);
        }

        static void FixDataSources(RdashDocument document)
        {
            Dictionary<string, DataSource> dataSources = new Dictionary<string, DataSource>();
            foreach (var visualization in document.Visualizations)
            {
                if (visualization is TextBoxVisualization) //TextBoxVisualization does not require a data source so there is no need to fix it
                    continue;

                if (visualization is IDataDefinitionProvider<DataDefinitionBase> iddp)
                {
                    var dsi = iddp.DataDefinition?.DataSourceItem;
                    if (dsi == null) 
                        throw new Exception($"Data source item for visualization {visualization.Title} is null.");

                    if (dsi.DataSource != null)
                    {
                        if (!dataSources.ContainsKey(dsi.DataSource.Id))
                            dataSources.Add(dsi.DataSource.Id, dsi.DataSource);

                        if (dsi.ResourceItemDataSource != null && !dataSources.ContainsKey(dsi.ResourceItemDataSource.Id))
                            dataSources.Add(dsi.ResourceItemDataSource.Id, dsi.ResourceItemDataSource);
                    }
                    else
                    {
                        ValidateManuallyAddedDataSourceItem(document, dsi);
                    }
                }
            }

            var allDataSources = document.DataSources?.Union(dataSources.Values.ToArray());
            document.DataSources = allDataSources?.ToList();
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
    }
}
