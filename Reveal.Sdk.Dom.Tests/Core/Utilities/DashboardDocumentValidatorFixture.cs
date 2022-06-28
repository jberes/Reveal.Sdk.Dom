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
            var excelDataSource = new ExcelDataSource();
            var excelDataSourceItem = new ExcelDataSourceItem(excelDataSource, new List<Field>());

            var document = new DashboardDocument();
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));

            Assert.Empty(document.DataSources);

            DashboardDocumentValidator.FixDashboardDocument(document);

            Assert.True(document.DataSources.Skip(1).Any());
        }

        [Fact]
        public void DataSources_FromVisualizationsAreNotDuplicated()
        {
            var excelDataSource = new ExcelDataSource();
            var excelDataSourceItem = new ExcelDataSourceItem(excelDataSource, new List<Field>());

            var document = new DashboardDocument();
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));

            Assert.Empty(document.DataSources);

            DashboardDocumentValidator.FixDashboardDocument(document);

            var excelDataSources = document.DataSources.Where(x => x.Provider == DataSourceProviders.ExcelProvider);

            Assert.Single(excelDataSources);
        }

        [Fact]
        public void DataSources_FromVisualizations_AndDataSources_AreNotDuplicated()
        {
            var excelDataSource = new ExcelDataSource();
            var excelDataSourceItem = new ExcelDataSourceItem(excelDataSource, new List<Field>());

            var document = new DashboardDocument();
            document.DataSources.Add(excelDataSource);

            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(excelDataSourceItem));

            Assert.Single(document.DataSources);

            DashboardDocumentValidator.FixDashboardDocument(document);

            var excelDataSources = document.DataSources.Where(x => x.Provider == DataSourceProviders.ExcelProvider);

            Assert.Single(excelDataSources);
        }
    }
}
