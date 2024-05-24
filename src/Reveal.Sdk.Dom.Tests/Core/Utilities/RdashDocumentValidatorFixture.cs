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

            RdashDocumentValidator.Validate(document);

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

            RdashDocumentValidator.Validate(document);

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

            RdashDocumentValidator.Validate(document);

            var jsonDataSources = document.DataSources.Where(x => x.Provider == DataSourceProvider.JSON);

            Assert.Single(jsonDataSources);
        }

        [Fact]
        public void Validate_Adds_Fields()
        {
            var dataSourceItem = new DataSourceItem("Test", new DataSource()).SetFields(new List<IField> { new TextField() });

            var document = new RdashDocument();
            document.Visualizations.Add(new GridVisualization(dataSourceItem));

            Assert.Empty(document.Visualizations[0].DataDefinition.AsTabular().Fields);

            RdashDocumentValidator.Validate(document);

            Assert.Single(document.Visualizations[0].DataDefinition.AsTabular().Fields);
        }

        [Fact]
        public void Validate_PreventsDuplicate_Fields()
        {
            var dataSourceItem = new DataSourceItem("Test", new DataSource()).SetFields(new List<IField>
            {
                new TextField("Test"),
                new TextField("Test")
            });

            var document = new RdashDocument();
            document.Visualizations.Add(new GridVisualization(dataSourceItem));

            Assert.Empty(document.Visualizations[0].DataDefinition.AsTabular().Fields);

            RdashDocumentValidator.Validate(document);

            Assert.Single(document.Visualizations[0].DataDefinition.AsTabular().Fields);
        }

        [Fact]
        public void Validate_Adds_JoinTables()
        {
            var dataSourceItem = new DataSourceItem("Test", new DataSource()).SetFields(new List<IField> { new TextField() });
            var joinConditions = new List<JoinCondition> { new JoinCondition("left", "right") };
            var dataSourceItemToJoin = new DataSourceItem().SetFields(new List<IField> { new TextField() });

            dataSourceItem.Join("Alias", joinConditions, dataSourceItemToJoin);

            var document = new RdashDocument();
            document.Visualizations.Add(new GridVisualization(dataSourceItem));

            Assert.Empty(document.Visualizations[0].DataDefinition.AsTabular().JoinTables);

            RdashDocumentValidator.Validate(document);

            Assert.Single(document.Visualizations[0].DataDefinition.AsTabular().JoinTables);
        }

        [Fact]
        public void Validate_ThrowsException_WhenDataSourceItem_WithDataSourceId_CantFindDataSource()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem() { DataSourceId = "TEST", Fields = new List<IField>() { new TextField() } };
            var viz = new GridVisualization("TEST", dataSourceItem)
            {
                Title = "Test Visualization",
            };
            var document = new RdashDocument("Test");
            document.Visualizations.Add(viz);

            // Act & Assert
            Assert.Throws<Exception>(() => RdashDocumentValidator.Validate(document));
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
