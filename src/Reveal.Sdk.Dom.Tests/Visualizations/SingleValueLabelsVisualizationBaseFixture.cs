using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Collections.Generic;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class SingleValueLabelsVisualizationBaseFixture
    {
        [Theory]
        [InlineData("testTitle")]
        [InlineData(null)]
        public void Constructor_SetTitleAndDataSourceItem_WhenConstructed(String title)
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();

            // Act
            var visualization = new TestSingleValueLabelsVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, visualization.Title);
            Assert.Equal(dataSourceItem, visualization.DataDefinition.DataSourceItem);
            Assert.IsType<SingleValueLabelsVisualizationDataSpec>(visualization.VisualizationDataSpec);
        }

        [Theory]
        [InlineData("SingleValueLabelsVisualizationDataSpec")]
        [InlineData("CategoryVisualizationDataSpec")]
        public void VisualizationDataSpec_GetSetAsExpected_WhenUse(String type)
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var visualization = new TestSingleValueLabelsVisualization("testTitle", dataSourceItem);
            VisualizationDataSpec dataSpec = type == "SingleValueLabelsVisualizationDataSpec" ? new SingleValueLabelsVisualizationDataSpec() : new CategoryVisualizationDataSpec();

            // Act
            visualization.VisualizationDataSpec = dataSpec;

            // Assert
            Assert.Equal(dataSpec, visualization.VisualizationDataSpec);
            if (type == "SingleValueLabelsVisualizationDataSpec")
            {
                Assert.IsType<SingleValueLabelsVisualizationDataSpec>(visualization.VisualizationDataSpec);
            }
            else
            {
                Assert.IsType<CategoryVisualizationDataSpec>(visualization.VisualizationDataSpec);
            }

        }

        [Fact]
        public void GetLabels_ReturnsVisualizationSpecRows_IfDataSpecIsSingleValueLabelsVisDataSpec()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var visualization = new TestSingleValueLabelsVisualization("testTitle", dataSourceItem);
            var visSpec = new SingleValueLabelsVisualizationDataSpec()
            {
                Rows = new List<DimensionColumn>
                {
                    new(),
                    new(),
                }
            };
            visualization.VisualizationDataSpec = visSpec;

            // Act
            var labels = visualization.Labels;

            // Assert
            Assert.NotNull(labels);
            Assert.Equal(2, labels.Count);
            Assert.Equal(visSpec.Rows, labels);
        }

        [Fact]
        public void GetLabels_ReturnsEmptyList_IfDataSpecIsNotSingleValueLabelsVisDataSpec()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var visualization = new TestSingleValueLabelsVisualization("testTitle", dataSourceItem);
            var visSpec = new CategoryVisualizationDataSpec();
            visualization.VisualizationDataSpec = visSpec;

            // Act
            var labels = visualization.Labels;

            // Assert
            Assert.NotNull(labels);
            Assert.Empty(labels);
        }

        [Fact]
        public void GetValues_ReturnsVisualizationSpecValue_IfDataSpecIsSingleValueLabelsVisDataSpec()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var visualization = new TestSingleValueLabelsVisualization("testTitle", dataSourceItem);
            var visSpec = new SingleValueLabelsVisualizationDataSpec()
            {
                Value = new List<MeasureColumn>
                {
                    new(),
                    new(),
                }
            };
            visualization.VisualizationDataSpec = visSpec;

            // Act
            var values = visualization.Values;

            // Assert
            Assert.NotNull(values);
            Assert.Equal(2, values.Count);
            Assert.Equal(visSpec.Value, values);
        }

        [Fact]
        public void GetValues_ReturnsEmptyList_IfDataSpecIsNotSingleValueLabelsVisDataSpec()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var visualization = new TestSingleValueLabelsVisualization("testTitle", dataSourceItem);
            var visSpec = new CategoryVisualizationDataSpec();
            visualization.VisualizationDataSpec = visSpec;

            // Act
            var values = visualization.Values;

            // Assert
            Assert.NotNull(values);
            Assert.Empty(values);
        }


        private class TestSingleValueLabelsVisualization : SingleValueLabelsVisualizationBase<TestVisualizationSettings>
        {
            public TestSingleValueLabelsVisualization(string title, DataSourceItem dataSourceItem) : base(title, dataSourceItem)
            {
            }
        }

        private class TestVisualizationSettings: VisualizationSettings
        {
        }
    }
}
