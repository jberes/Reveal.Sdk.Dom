using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Core.Utilities
{
    public class RdashDocumentValidatorFixture
    {
        [Fact]
        public void DataSources_AddedToRdashDocument()
        {
            var dataSourceItem = new RestServiceBuilder("").SetFields(new List<IField>() { null }).Build();

            var document = new RdashDocument();
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Empty(document.DataSources);

            RdashDocumentValidator.FixDocument(document);

            Assert.True(document.DataSources.Skip(1).Any());
        }

        [Fact]
        public void DataSources_FromVisualizationsAreNotDuplicated()
        {
            var dataSourceItem = new RestServiceBuilder("").SetFields(new List<IField>() { null }).Build();

            var document = new RdashDocument();
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Empty(document.DataSources);

            RdashDocumentValidator.FixDocument(document);

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProvider.JSON);

            Assert.Single(jsonDataSources);
        }

        [Fact]
        public void DataSources_FromVisualizations_AndDataSources_AreNotDuplicated()
        {
            var dataSourceItem = new RestServiceBuilder("").SetFields(new List<IField>() { null }).Build();
            var dataSource = dataSourceItem.DataSource;

            var document = new RdashDocument();
            document.DataSources.Add(dataSource);

            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Single(document.DataSources);

            RdashDocumentValidator.FixDocument(document);

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProvider.JSON);

            Assert.Single(jsonDataSources);
        }
    }
}
