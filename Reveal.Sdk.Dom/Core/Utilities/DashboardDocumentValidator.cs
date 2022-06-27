using Reveal.Sdk.Dom.Data;
using System.Collections.Generic;
using System.Linq;

namespace Reveal.Sdk.Dom.Core.Utilities
{
    internal static class DashboardDocumentValidator
    {
        internal static void FixDashboardDocument(DashboardDocument document)
        {
            FixDataSources(document);
        }

        static void FixDataSources(DashboardDocument document)
        {
            Dictionary<string, DataSource> dataSources = new Dictionary<string, DataSource>();
            foreach (var viz in document.Visualizations)
            {
                var dsi = viz.DataSpec?.DataSourceItem;
                if (dsi != null)
                {
                    if (dsi.DataSource != null && !dataSources.ContainsKey(dsi.DataSource.Id))
                        dataSources.Add(dsi.DataSource.Id, dsi.DataSource);

                    if (dsi.ResourceItemDataSource != null && !dataSources.ContainsKey(dsi.ResourceItemDataSource.Id))
                        dataSources.Add(dsi.ResourceItemDataSource.Id, dsi.ResourceItemDataSource);
                }
            }

            var allDataSources = document.DataSources?.Union(dataSources.Values.ToArray());
            document.DataSources = allDataSources?.ToList();
        }
    }
}
