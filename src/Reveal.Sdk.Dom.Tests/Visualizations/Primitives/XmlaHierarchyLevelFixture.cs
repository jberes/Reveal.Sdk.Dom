using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class XmlaHierarchyLevelFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new XmlaHierarchyLevel();

            // Assert
            Assert.Equal(SchemaTypeNames.XmlaHierarchyLevelType, instance.SchemaTypeName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var instance = new XmlaHierarchyLevel()
            {
                HierarchyUniqueName = "HierarchyUniqueName",
                LevelNumber = 1,
                Cardinality = 2,
            };

            var expectedJson = """
            {
              "_type": "XmlaHierarchyLevelType",
              "HierarchyUniqueName": "HierarchyUniqueName",
              "LevelNumber": 1,
              "Cardinality": 2,
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
