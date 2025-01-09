using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class JoinConditionFixture
    {
        [Fact]
        public void Constructor_SetValues_WithJoinFields()
        {
            // Act
            var instance = new JoinCondition("Left Field", "Right Field");

            // Assert
            Assert.Equal("Left Field", instance.LeftFieldName);
            Assert.Equal("Right Field", instance.RightFieldName);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var instance = new JoinCondition("Left Field", "Right Field");

            var expectedJson = """
            {
              "LeftFieldName": "Left Field",
              "RightFieldName": "Right Field"
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
