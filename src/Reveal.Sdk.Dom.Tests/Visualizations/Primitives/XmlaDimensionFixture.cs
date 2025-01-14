using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xunit;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Core.Constants;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class XmlaDimensionFixture
    {
        [Fact]
        public void Constructor_SchemaTypeIsDimensionColSpecType_WhenConstructed()
        {

            // Act
            var instance = new XmlaDimension();

            // Assert
            Assert.Equal(SchemaTypeNames.XmlaDimensionType, instance.SchemaTypeName);
        }

        [Fact]
        public void ConvertToJson_UseExpectedFields_WhenCalled()
        {
            // Arrange
            var instance = new XmlaDimension()
            {
                DefaultHierarchy = "DefaultHierarchy"
            };

            var expectedJson = JObject.Parse("""
            {
              "_type": "XmlaDimensionType",
              "DefaultHierarchy": "DefaultHierarchy",
              "DimensionType": "Regular",
              "DrillDownElements": [],
              "Sorting": "None",
              "FieldSortingByLabel": false,
              "FullyExpandedLevels": 0,
              "ExpandedItems": [],
              "DateAggregationType": "Year",
              "DateFiscalYearStartMonth": 0,
              "DrillDownMembers": []
            }
            """);

            // Act
            var outputJson = JsonConvert.SerializeObject(instance, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            // Assert
            Assert.Equal(expectedJson.ToString(), outputJson);
        }
    }
}
