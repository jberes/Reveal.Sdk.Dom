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
    public class XmlaMeasureFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new XmlaMeasure();

            // Assert
            Assert.Equal(SortingType.None, instance.Sorting);
            Assert.Empty(((IMetadata)instance).Metadata);
        }

        [Fact]
        public void Description_GetSetCorrectly_WhenUsed()
        {
            // Arrange
            var instance = new XmlaMeasure();
            var description = "TestDescription";

            // Act
            instance.Description = description;

            // Assert
            Assert.Equal(description, instance.Description);
            Assert.Equal(description, ((IMetadata)instance).Metadata["Description"]);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var instance = new XmlaMeasure()
            {
                IsHidden = false,
                UniqueName = "UniqueName",
                Caption = "Caption",
                DisplayFolder = "DisplayFolder",
                MeasureGroupName = "MeasureGroupName",
                UserCaption = "UserCaption",
                IsCalculated = false,
                Expression = "Expression",
                Formatting = new NumberFormatting(),
                ConditionalFormatting = new ConditionalFormatting(),
                Description = "Description",
                Sorting = SortingType.Asc,
            };

            ((IMetadata)instance).Metadata.Add("MetadataKey", "MetadataValue");

            var expectedJson = """
            {
              "IsHidden": false,
              "UniqueName": "UniqueName",
              "Caption": "Caption",
              "DisplayFolder": "DisplayFolder",
              "MeasureGroupName": "MeasureGroupName",
              "UserCaption": "UserCaption",
              "IsCalculated": false,
              "Expression": "Expression",
              "Formatting": {
                "_type": "NumberFormattingSpecType",
                "ApplyMkFormat": false,
                "CurrencySymbol": "$",
                "DecimalDigits": 2,
                "FormatType": "Number",
                "NegativeFormat": "MinusSign",
                "ShowGroupingSeparator": false,
                "OverrideDefaultSettings": false
              },
              "ConditionalFormatting": {
                "Minimum": {
                  "ValueType": "LowestValue"
                },
                "Maximum": {
                  "ValueType": "HighestValue"
                },
                "Bands": [
                  {
                    "_type": "ConditionalFormattingBandType",
                    "Shape": "Circle",
                    "Type": "Percentage",
                    "Color": "Green",
                    "Value": 80.0
                  },
                  {
                    "_type": "ConditionalFormattingBandType",
                    "Shape": "Circle",
                    "Type": "Percentage",
                    "Color": "Yellow",
                    "Value": 50.0
                  },
                  {
                    "_type": "ConditionalFormattingBandType",
                    "Shape": "Circle",
                    "Type": "Percentage",
                    "Color": "Red"
                  }
                ]
              },
              "Sorting": "Asc",
              "Metadata": {
                "Description": "Description",
                "MetadataKey": "MetadataValue"
              }
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
