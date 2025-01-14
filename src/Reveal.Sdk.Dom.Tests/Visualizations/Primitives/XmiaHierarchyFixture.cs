using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class XmiaHierarchyFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new XmlaHierarchy();

            // Assert
            Assert.Equal(SchemaTypeNames.XmlaHierarchyType, instance.SchemaTypeName);
            Assert.Null(instance.Cardinality);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var instance = new XmlaHierarchy()
            {
                Origin = 1,
                Description = "Description",
                Cardinality = 1,
                DisplayFolder = "DisplayFolder",
                AllMember = "AllMember",
                DefaultMember = "DefaultMember"
            };

            var expectedJson = """
            {
              "_type": "XmlaHierarchyType",
              "Origin": 1,
              "Description": "Description",
              "Cardinality": 1,
              "DisplayFolder": "DisplayFolder",
              "AllMember": "AllMember",
              "DefaultMember": "DefaultMember",
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
            """;

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
