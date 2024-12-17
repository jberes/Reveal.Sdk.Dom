using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Visualizations.Settings;
using Reveal.Sdk.Dom.Visualizations.VisualizationSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations
{
    public class PivotVisualizationFixture
    {
        [Fact]
        public void PivotVisualization_DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            var pivotVisualization = new PivotVisualization();

            // Assert
            Assert.NotNull(pivotVisualization);
            Assert.Equal(ChartType.Pivot, pivotVisualization.ChartType);
            Assert.NotNull(pivotVisualization.Columns);
            Assert.Empty(pivotVisualization.Columns);
            Assert.NotNull(pivotVisualization.Rows);
            Assert.Empty(pivotVisualization.Rows);
            Assert.NotNull(pivotVisualization.Values);
            Assert.Empty(pivotVisualization.Values);
        }

        [Theory]
        [InlineData("TestTitle", null)]
        [InlineData(null, null)]
        public void PivotVisualization_ConstructorWithTitleAndDataSource_ShouldSetValues(string title, DataSourceItem dataSourceItem)
        {
            // Act
            var pivotVisualization = new PivotVisualization(title, dataSourceItem);

            // Assert
            Assert.Equal(title, pivotVisualization.Title);
            Assert.Equal(ChartType.Pivot, pivotVisualization.ChartType);
            Assert.NotNull(pivotVisualization.Columns);
            Assert.Empty(pivotVisualization.Columns);
            Assert.NotNull(pivotVisualization.Rows);
            Assert.Empty(pivotVisualization.Rows);
            Assert.NotNull(pivotVisualization.Values);
            Assert.Empty(pivotVisualization.Values);
        }

        [Fact]
        public void PivotVisualizationSettings_DefaultValues_ShouldBeCorrect()
        {
            // Act
            var settings = new PivotVisualizationSettings();

            // Assert
            Assert.Equal(SchemaTypeNames.PivotVisualizationSettingsType, settings.SchemaTypeName);
            Assert.Equal(VisualizationTypes.PIVOT, settings.VisualizationType);
        }
    }
}
