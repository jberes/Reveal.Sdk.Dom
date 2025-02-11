using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations;

public class TextVisualizationFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var visualization = new TextVisualization();

        // Assert
        Assert.Null(visualization.Title);
        Assert.Null(visualization.DataDefinition);
        Assert.Equal(ChartType.Text, visualization.ChartType);
    }

    [Fact]
    public void Constructor_SetsDataSourceItem_WhenOnlyDataSourceItemProvided()
    {
        // Arrange
        var dataSourceItem = new DataSourceItem();

        // Act
        var visualization = new TextVisualization(dataSourceItem);

        // Assert
        Assert.Equal(dataSourceItem, visualization.DataDefinition.DataSourceItem);
        Assert.Equal(ChartType.Text, visualization.ChartType);
    }

    [Fact]
    public void Constructor_SetsTitleAndDataSourceItem_WhenBothArgumentsAreProvided()
    {
        // Arrange
        var title = "Text Visualization";
        var dataSourceItem = new DataSourceItem();

        // Act
        var visualization = new TextVisualization(title, dataSourceItem);

        // Assert
        Assert.Equal(title, visualization.Title);
        Assert.Equal(dataSourceItem, visualization.DataDefinition.DataSourceItem);
        Assert.Equal(ChartType.Text, visualization.ChartType);
    }
}