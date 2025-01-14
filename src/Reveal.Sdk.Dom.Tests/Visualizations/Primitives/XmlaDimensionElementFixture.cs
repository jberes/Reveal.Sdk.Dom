using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class XmlaDimensionElementFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new TestXmlaDimensionElement();

            // Assert
            Assert.Equal(XmlaDimensionType.Regular, instance.DimensionType);
            Assert.Empty(instance.DrillDownElements);
            Assert.Equal(SortingType.None, instance.Sorting);
            Assert.Empty(instance.ExpandedItems);
            Assert.Equal(DateAggregationType.Year, instance.DateAggregationType);
            Assert.Empty(instance.DrillDownMembers);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var instance = new TestXmlaDimensionElement()
            {
                DimensionType = XmlaDimensionType.Date,
                DrillDownElements = new List<string>() { "Element 1", "Element 2" },
                Sorting = SortingType.Asc,
                UniqueName = "Unique Name",
                Caption = "Caption",
                UserCaption = "User Caption",
                DimensionUniqueName = "Dimension Unique Name",
                FieldSortingByLabel = true,
                XmlaFilter = new Filters.XmlaFilter(),
                ExpandedItems = new List<string>() { "Expanded Item 1", "Expanded Item 2" },
                DateAggregationType = DateAggregationType.Day,
                DateFiscalYearStartMonth = 20,
                DrillDownMembers = new List<XmlaMember>() { new XmlaMember() },
            };

            var expectedJson = """
            {
              "UniqueName": "Unique Name",
              "Caption": "Caption",
              "UserCaption": "User Caption",
              "DimensionUniqueName": "Dimension Unique Name",
              "DimensionType": "Date",
              "DrillDownElements": [
                "Element 1",
                "Element 2"
              ],
              "Sorting": "Asc",
              "FieldSortingByLabel": true,
              "XmlaFilter": {
                "DataType": "String",
                "ElementType": "Dimension",
                "IsDynamic": false
              },
              "FullyExpandedLevels": 0,
              "ExpandedItems": [
                "Expanded Item 1",
                "Expanded Item 2"
              ],
              "DateAggregationType": "Day",
              "DateFiscalYearStartMonth": 20,
              "DrillDownMembers": [
                {}
              ]
            }
            """;

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }

        private class TestXmlaDimensionElement : XmlaDimensionElement { }
    }
}
