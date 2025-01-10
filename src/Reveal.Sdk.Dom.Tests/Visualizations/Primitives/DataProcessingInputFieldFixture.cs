using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class DataProcessingInputFieldFixture
    {

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "ResultColumnName": "Test ResultColumnName",
              "InputColumnName": "Test InputColumnName",
              "FixedValue": "Test FixedValue"
            }
            """;

            var instance = new DataProcessingInputField();
            instance.ResultColumnName = "Test ResultColumnName";
            instance.InputColumnName = "Test InputColumnName";
            instance.FixedValue = "Test FixedValue";

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
