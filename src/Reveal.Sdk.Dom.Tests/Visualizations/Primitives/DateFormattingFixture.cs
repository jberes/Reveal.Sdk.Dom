using Newtonsoft.Json;
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
    public class DateFormattingFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new DateFormatting();

            // Assert
            Assert.Equal(SchemaTypeNames.DateFormattingSpecType, instance.SchemaTypeName);
            Assert.Null(instance.DateFormat);
        }

        [Fact]
        public void Constructor_SetFieldName_WhenConstructedWithDateFormat()
        {
            // Arrange
            var dateFormat = "dd MMM yyyy";

            // Act
            var instance = new DateFormatting(dateFormat);

            // Assert
            Assert.Equal(SchemaTypeNames.DateFormattingSpecType, instance.SchemaTypeName);
            Assert.Equal(dateFormat, instance.DateFormat);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "_type": "DateFormattingSpecType",
              "DateFormat": "dd MMM yyyy",
              "OverrideDefaultSettings": false
            }
            """;
            var dateFormat = "dd MMM yyyy";

            var instance = new DateFormatting(dateFormat);

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
