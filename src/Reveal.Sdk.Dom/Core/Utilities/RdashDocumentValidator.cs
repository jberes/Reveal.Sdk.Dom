using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
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
                if (visualization is IDataDefinitionProvider<DataDefinitionBase> iddp)
                {
                    var dsi = iddp.DataDefinition?.DataSourceItem;
                    if (dsi != null)
                    {
                        if (dsi.DataSource != null && !dataSources.ContainsKey(dsi.DataSource.Id))
                            dataSources.Add(dsi.DataSource.Id, dsi.DataSource);

                        if (dsi.ResourceItemDataSource != null && !dataSources.ContainsKey(dsi.ResourceItemDataSource.Id))
                            dataSources.Add(dsi.ResourceItemDataSource.Id, dsi.ResourceItemDataSource);
                    }
                }                
            }

            var allDataSources = document.DataSources?.Union(dataSources.Values.ToArray());
            document.DataSources = allDataSources?.ToList();
        }
    }
}
