using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Core.Utilities
{
    public class DashboardDocumentValidatorFixture
    {
        [Fact]
        public void DataSources_AddedToDashboardDocument()
        {
            var dataSourceItem = new RestBuilder("").SetFields(new List<Field>() { null }).Build();

            var document = new DashboardDocument();
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Empty(document.DataSources);

            DashboardDocumentValidator.FixDashboardDocument(document);

            Assert.True(document.DataSources.Skip(1).Any());
        }

        [Fact]
        public void DataSources_FromVisualizationsAreNotDuplicated()
        {
            var dataSourceItem = new RestBuilder("").SetFields(new List<Field>() { null }).Build();

            var document = new DashboardDocument();
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Empty(document.DataSources);

            DashboardDocumentValidator.FixDashboardDocument(document);

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProviders.JSON);

            Assert.Single(jsonDataSources);
        }

        [Fact]
        public void DataSources_FromVisualizations_AndDataSources_AreNotDuplicated()
        {
            var dataSourceItem = new RestBuilder("").SetFields(new List<Field>() { null }).Build();
            var dataSource = dataSourceItem.DataSource;

            var document = new DashboardDocument();
            document.DataSources.Add(dataSource);

            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Single(document.DataSources);

            DashboardDocumentValidator.FixDashboardDocument(document);

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProviders.JSON);

            Assert.Single(jsonDataSources);
        }
    }
}
