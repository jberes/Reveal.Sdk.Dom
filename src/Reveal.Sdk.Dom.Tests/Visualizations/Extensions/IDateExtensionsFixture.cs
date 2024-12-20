using Reveal.Sdk.Dom.Visualizations;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IDateExtensionsFixture
    {
        [Fact]
        public void SetDate_UpdateFieldDate_WithFieldName()
        {
            // Arrange
            var visualization = new MockIDateVisualization()
            {
                Date = new DimensionColumn() { DataField = new DateDataField("InitialField") }
            };
            var fieldName = "TestField";
            var expectedDateFieldValue = new DimensionColumn { DataField = new DateDataField(fieldName) };

            // Act
            visualization.SetDate(fieldName);

            // Assert
            Assert.Equivalent(expectedDateFieldValue, visualization.Date);
        }

        [Fact]
        public void SetDate_UpdateFieldDate_WithDateDataField()
        {
            // Arrange
            var visualization = new MockIDateVisualization()
            {
                Date = new DimensionColumn() { DataField = new DateDataField("InitialField") }
            };
            var field = new DateDataField("TestField");
            var expectedDateFieldValue = new DimensionColumn { DataField = field };

            // Act
            visualization.SetDate(field);

            // Assert
            Assert.Equivalent(expectedDateFieldValue, visualization.Date);
        }

        private class MockIDateVisualization : IDate
        {
            public DimensionColumn Date { get; set; }
        }
    }
}
