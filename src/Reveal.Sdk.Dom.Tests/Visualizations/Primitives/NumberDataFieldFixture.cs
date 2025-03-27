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
    public class NumberDataFieldFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var field = new NumberDataField();

            // Assert
            Assert.Equal(SchemaTypeNames.SummarizationValueFieldType, field.SchemaTypeName);
            Assert.Equal(string.Empty, field.FieldName);
            Assert.Equal(AggregationType.Sum, field.AggregationType);
            Assert.Equal(SortingType.None, field.Sorting);

        }

        [Fact]
        public void Constructor_SetFieldName_WhenConstructedWithFieldName()
        {
            // Arrange
            var fieldName = "FieldName";

            // Act
            var field = new NumberDataField(fieldName);

            // Assert
            Assert.Equal(SchemaTypeNames.SummarizationValueFieldType, field.SchemaTypeName);
            Assert.Equal(fieldName, field.FieldName);
            Assert.Equal(fieldName, field.FieldLabel);
            Assert.Equal(fieldName, field.UserCaption);
            Assert.Equal(AggregationType.Sum, field.AggregationType);
            Assert.Equal(SortingType.None, field.Sorting);
        }

        [Fact]
        public void SetFieldLabel_AlsoSetUserCaption_WhenSet()
        {
            // Arrange
            var field = new NumberDataField();
            var fieldLabel = "FieldLabel";

            // Act
            field.FieldLabel = fieldLabel;

            // Assert
            Assert.Equal(fieldLabel, field.FieldLabel);
            Assert.Equal(fieldLabel, field.UserCaption);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "_type": "SummarizationValueFieldType",
              "FieldLabel": "FieldLabel",
              "UserCaption": "FieldLabel",
              "IsHidden": false,
              "AggregationType": "Sum",
              "Sorting": "None",
              "IsCalculated": false,
              "Formatting": {
                "_type": "NumberFormattingSpecType",
                "ApplyMkFormat": false,
                "CurrencySymbol": "$",
                "DecimalDigits": 4,
                "FormatType": "Currency",
                "NegativeFormat": "Parenthesis",
                "ShowGroupingSeparator": false,
                "OverrideDefaultSettings": false,
                "ShowDataLabelsInChart": true
               },
              "FieldName": "FieldName"
            }
            """;
            var fieldName = "FieldName";

            var field = new NumberDataField(fieldName);
            field.FieldLabel = "FieldLabel";

            // Act
            var actualJson = field.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}