using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations;

public class TextBoxVisualizationFixture
{
    [Fact]
    public void Constructor_FieldsHaveDefaultValues_WhenInstanceIsCreated()
    {
        // Act
        var visualization = new TextBoxVisualization();

        // Assert
        Assert.Null(visualization.Title);
        Assert.Equal(ChartType.TextBox, visualization.ChartType);
        Assert.NotNull(visualization.DataDefinition);
        Assert.IsType<TextBoxDataDefinition>(visualization.DataDefinition);
        Assert.Null(visualization.Text);
        Assert.Equal(FontSize.Medium, visualization.FontSize);
        Assert.Equal(Alignment.Left, visualization.Alignment);
    }

    [Fact]
    public void Constructor_SetsTitle_WhenTitleIsProvided()
    {
        // Arrange
        var title = "Sample TextBox";

        // Act
        var visualization = new TextBoxVisualization(title);

        // Assert
        Assert.Equal(title, visualization.Title);
        Assert.Equal(ChartType.TextBox, visualization.ChartType);
        Assert.NotNull(visualization.DataDefinition);
        Assert.IsType<TextBoxDataDefinition>(visualization.DataDefinition);
    }

    [Fact]
    public void Alignment_GetAndSet_ReturnsCorrectValue()
    {
        // Arrange
        var visualization = new TextBoxVisualization();
        var expectedAlignment = Alignment.Center;

        // Act
        visualization.Alignment = expectedAlignment;

        // Assert
        Assert.Equal(expectedAlignment, visualization.Alignment);
        Assert.Equal(expectedAlignment, ((TextBoxDataDefinition)visualization.DataDefinition).Alignment);
    }

    [Fact]
    public void FontSize_GetAndSet_ReturnsCorrectValue()
    {
        // Arrange
        var visualization = new TextBoxVisualization();
        var expectedFontSize = FontSize.Large;

        // Act
        visualization.FontSize = expectedFontSize;

        // Assert
        Assert.Equal(expectedFontSize, visualization.FontSize);
        Assert.Equal(expectedFontSize, ((TextBoxDataDefinition)visualization.DataDefinition).FontSize);
    }

    [Fact]
    public void Text_GetAndSet_ReturnsCorrectValue()
    {
        // Arrange
        var visualization = new TextBoxVisualization();
        var expectedText = "This is a sample text.";

        // Act
        visualization.Text = expectedText;

        // Assert
        Assert.Equal(expectedText, visualization.Text);
        Assert.Equal(expectedText, ((TextBoxDataDefinition)visualization.DataDefinition).Text);
    }

    [Fact]
    public void DataDefinition_IsInitializedCorrectly_WhenCreated()
    {
        // Act
        var visualization = new TextBoxVisualization();

        // Assert
        Assert.NotNull(visualization.DataDefinition);
        Assert.IsType<TextBoxDataDefinition>(visualization.DataDefinition);
        var dataDefinition = (TextBoxDataDefinition)visualization.DataDefinition;
        Assert.Null(dataDefinition.Bindings);
    }
    
    [Fact]
    public void ToJsonString_GeneratesCorrectJson_WhenSerialized()
    {
        // Arrange
        var expectedJson = 
            """
            [ {
              "Id" : "33077d1e-19c5-44fe-b981-6765af3156a8",
              "Title" : "TextBox",
              "IsTitleVisible" : true,
              "ColumnSpan" : 0,
              "RowSpan" : 0,
              "VisualizationSettings" : {
                "_type" : "TextBoxVisualizationSettingsType",
                "VisualizationType" : "TEXT_BOX"
              },
              "DataSpec" : {
                "_type" : "TextBoxDataSpecType",
                "Text" : "This is some text",
                "FontSize" : "Large",
                "Alignment" : "Left",
                "Expiration" : 1440
              }
            } ]
            """;

        var document = new RdashDocument("My Dashboard");
        
        var excelDataSourceItem = new RestDataSourceItem("Marketing Sheet")
        {
            Id = "080cc17d-4a0a-4837-aa3f-ef2571ea443a",
            Subtitle = "Excel Data Source Item",
            Url = "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx",
            IsAnonymous = true,
            ResourceItem = new DataSourceItem
            {
                Id = "d593dd79-7161-4929-afc9-c26393f5b650",
                DataSourceId = "33077d1e-19c5-44fe-b981-6765af3156a6",
                Title = "Marketing Sheet",
                Subtitle = "Excel Data Source Item",
                HasTabularData = true,
                HasAsset = false,
                Properties = new Dictionary<string, object>
                {
                    { "Url", "http://dl.infragistics.com/reportplus/reveal/samples/Samples.xlsx" }
                }
            },
            Fields = new List<IField>
            {
                new DateField("Date"),
            }
        };
        excelDataSourceItem.UseExcel("Marketing");
        
        document.Visualizations.Add(new TextBoxVisualization("TextBox")
            {
                Id = "33077d1e-19c5-44fe-b981-6765af3156a8"
            }
            .SetText("This is some text")
            .SetFontSize(FontSize.Large));

        // Act
        var json = document.ToJsonString();
        var actualJson = JObject.Parse(json)["Widgets"];
        var actualNormalized = JsonConvert.SerializeObject(actualJson, Formatting.Indented);
        var expectedNormalized = JArray.Parse(expectedJson).ToString(Formatting.Indented);

        // Assert
        Assert.Equal(expectedNormalized.Trim(), actualNormalized.Trim());
    }
}