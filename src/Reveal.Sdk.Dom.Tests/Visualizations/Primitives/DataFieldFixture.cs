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
    public class DataFieldFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Arrange
            var fieldName = "FieldName";
            // Act
            var instance = new TestDataField(fieldName);

            // Assert
            Assert.Equal(fieldName, instance.FieldName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "FieldName": "Field name",
              "Description": "Test Description"
            }
            """;

            var instance = new TestDataField("Field name");
            instance.Description = "Test Description";

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }

        private class TestDataField: DataField
        {
            public TestDataField(string fieldName) : base(fieldName)
            {
            }
        }
    }
}
