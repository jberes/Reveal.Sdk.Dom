using Reveal.Sdk.Dom.Core.Utilities;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
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
            var dataSourceItem = new DataSourceItemFactory().Create(DataSourceType.REST, "", "").SetFields(new List<IField>() { new TextField("Test") });

            var document = new RdashDocument();
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Empty(document.DataSources);

            document.Validate();

            Assert.True(document.DataSources.Skip(1).Any());
        }

        [Fact]
        public void DataSources_FromVisualizationsAreNotDuplicated()
        {
            var dataSourceItem = new DataSourceItemFactory().Create(DataSourceType.REST, "", "").SetFields(new List<IField>() { new TextField("Test") });

            var document = new RdashDocument();
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Empty(document.DataSources);

            document.Validate();

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProvider.JSON);

            Assert.Single(jsonDataSources);
        }

        [Fact]
        public void DataSources_FromVisualizations_AndDataSources_AreNotDuplicated()
        {
            var dataSourceItem = new DataSourceItemFactory().Create(DataSourceType.REST, "", "").SetFields(new List<IField>() { new TextField("Test") });
            var dataSource = dataSourceItem.DataSource;

            var document = new RdashDocument();
            document.DataSources.Add(dataSource);

            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));
            document.Visualizations.Add(new KpiTimeVisualization(dataSourceItem));

            Assert.Single(document.DataSources);

            document.Validate();

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProvider.JSON);

            Assert.Single(jsonDataSources);
        }

        [Fact]
        public void Validate_ThrowsException_WhenDataSourceItemIsNull()
        {
            // Arrange
            var viz = new GridVisualization("TEST", null)
            {
                Title = "Test Visualization",
                DataDefinition = new TabularDataDefinition()
            };
            var document = new RdashDocument("Test");
            document.Visualizations.Add(viz);

            // Act & Assert
            Assert.Throws<Exception>(() => RdashDocumentValidator.Validate(document));
        }

        [Fact]
        public void Validate_ThrowsException_WhenFieldIsNull()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem()
            {
                Fields = new List<IField> { null }
            };

            var viz = new GridVisualization("TEST", dataSourceItem)
            {
                Title = "Test Visualization",
                DataDefinition = new TabularDataDefinition()
            };

            var document = new RdashDocument("Test");
            document.Visualizations.Add(viz);

            // Act & Assert
            Assert.Throws<Exception>(() => RdashDocumentValidator.Validate(document));
        }

        [Fact]
        public void Validate_ThrowsException_WhenFieldsAreNullOrEmpty()
        {
            var dataSourceItem = new DataSourceItem()
            {
                Fields = new List<IField> { null }
            };

            var viz = new GridVisualization("TEST", dataSourceItem)
            {
                Title = "Test Visualization",
                DataDefinition = new TabularDataDefinition()
            };

            var document = new RdashDocument("Test");
            document.Visualizations.Add(viz);

            // Act & Assert
            Assert.Throws<Exception>(() => RdashDocumentValidator.Validate(document));

            // Arrange
            var dataSourceItem2 = new DataSourceItem()
            {
                Fields = new List<IField>()
            };

            var viz2 = new GridVisualization("TEST", dataSourceItem2)
            {
                Title = "Test Visualization",
                DataDefinition = new TabularDataDefinition()
            };

            var document2 = new RdashDocument("Test");
            document2.Visualizations.Add(viz2);

            // Act & Assert
            Assert.Throws<Exception>(() => RdashDocumentValidator.Validate(document2));
        }
    }
}
