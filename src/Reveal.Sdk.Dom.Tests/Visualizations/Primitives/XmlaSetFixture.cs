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
    public class XmlaSetFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new XmlaSet();

            // Assert
            Assert.Equal(SchemaTypeNames.XmlaSetType, instance.SchemaTypeName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var instance = new XmlaSet()
            {
                HierarchyUniqueName = "HierarchyUniqueName",
                DisplayFolder = "DisplayFolder"
            };

            var expectedJson = """
            {
              "_type": "XmlaSetType",
              "HierarchyUniqueName": "HierarchyUniqueName",
              "DisplayFolder": "DisplayFolder",
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
