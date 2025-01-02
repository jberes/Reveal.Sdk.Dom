using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class MeasureColumnFixture
    {
        [Fact]
        public void Constructor_SchemaTypeIsDimensionColSpecType_WhenConstructed()
        {

            // Act
            var column = new MeasureColumn();

            // Assert
            Assert.Equal(SchemaTypeNames.MeasureColumnSpecType, column.SchemaTypeName);
        }

        [Fact]
        public void Constructor_SchemaTypeIsDimensionColSpecType_WhenConstructedWithDataField()
        {
            // Arrange
            var dataField = new TextDataField("test field");
            // Act
            var column = new MeasureColumn(dataField);

            // Assert
            Assert.Equal(dataField, column.DataField);
        }

        [Fact]
        public void ConvertToJson_UseExpectedFields_WhenCalled()
        {
            // Arrange
            var column = new MeasureColumn();
            column.DataField = new TextDataField("test field");
            column.XmlaMeasure = new XmlaMeasure();

            var expectedJson =  JObject.Parse("""
            {
                "SchemaTypeName": "MeasureColumnSpecType",
                "SummarizationField": {
                    "Name": "test field",
                    "SchemaTypeName": "TextDataField"
                },
                "XmlaElement": {
                    "Name": null,
                    "SchemaTypeName": "XmlaMeasure"
                }
            }
            """);

            // Act
            var outputJson = JsonConvert.SerializeObject(column, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            // Assert
            Assert.Equal(expectedJson.ToString(), outputJson);
        }

    }
}