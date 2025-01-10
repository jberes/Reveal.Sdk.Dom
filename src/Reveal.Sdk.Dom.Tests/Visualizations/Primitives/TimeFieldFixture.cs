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
    public class TimeFieldFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var field = new TimeField();

            // Assert
            Assert.Equal(DataType.Time, ((IFieldDataType)field).DataType);
            Assert.Equal(string.Empty, field.FieldName);
        }

        [Fact]
        public void Constructor_SetFieldName_WhenConstructedWithFieldName()
        {
            // Arrange
            var fieldName = "FieldName";

            // Act
            var field = new TimeField(fieldName);

            // Assert
            Assert.Equal(DataType.Time, ((IFieldDataType)field).DataType);
            Assert.Equal(fieldName, field.FieldName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
                "FieldName": "FieldName",
                "FieldLabel": "FieldName",
                "UserCaption": "FieldName",
                "IsCalculated": false,
                "Properties": {},
                "Sorting": "None",
                "FieldType": "Time"
            }
            """;
            var fieldName = "FieldName";

            // Act
            var field = new TimeField(fieldName);

            // Act
            var actualJson = field.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}

