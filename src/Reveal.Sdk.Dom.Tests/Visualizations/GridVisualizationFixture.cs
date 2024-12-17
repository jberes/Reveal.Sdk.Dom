using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{

    public class GridVisualizationTests
    {
        [Fact]
        public void GridVisualization_DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            var gridVisualization = new GridVisualization();

            // Assert
            Assert.NotNull(gridVisualization);
            Assert.Equal(ChartType.Grid, gridVisualization.ChartType);
            Assert.NotNull(gridVisualization.Columns);
            Assert.Empty(gridVisualization.Columns);
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        public void GridVisualization_ConstructorWithTitleAndDataSource_ShouldSetValues(string title, DataSourceItem dataSourceItem)
        {
            // Act
            var gridVisualization = new GridVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, gridVisualization.Title);
            Assert.Equal(ChartType.Grid, gridVisualization.ChartType);
            Assert.NotNull(gridVisualization.Columns);
            Assert.Empty(gridVisualization.Columns);
        }

        [Theory]
        [InlineData(true, 100)]
        [InlineData(false, 50)]
        public void GridVisualizationSettings_PageSettings_ShouldSetCorrectValues(bool pagingEnabled, int pageSize)
        {
            // Arrange
            var settings = new GridVisualizationSettings
            {
                IsPagingEnabled = pagingEnabled,
                PageSize = pageSize
            };

            // Act & Assert
            Assert.Equal(pagingEnabled, settings.IsPagingEnabled);
            Assert.Equal(pageSize, settings.PageSize);
        }

        [Fact]
        public void GridVisualizationSettings_IsFirstColumnFixed_ShouldUpdateStyleProperty()
        {
            // Arrange
            var settings = new GridVisualizationSettings();

            // Act
            settings.IsFirstColumnFixed = true;

            // Assert
            Assert.True(settings.IsFirstColumnFixed);
            Assert.True(settings.Style.FixedLeftColumns);
        }

        [Fact]
        public void UpdateDataSourceItem_ShouldUpdateDataDefinition_WhenValidDataSourceItemProvided()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem { HasTabularData = true };
            var gridVisualization = new GridVisualization("Test", dataSourceItem);

            var newDataSourceItem = new DataSourceItem();

            // Act
            gridVisualization.UpdateDataSourceItem(newDataSourceItem);

            // Assert
            Assert.Equal(newDataSourceItem, gridVisualization.DataDefinition.DataSourceItem);
        }
    }

}
