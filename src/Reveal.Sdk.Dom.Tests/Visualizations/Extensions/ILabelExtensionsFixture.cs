using Moq;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class ILabelExtensionsFixture
    {
        [Fact]
        public void SetLabel_UpdateLabel_WithFieldName() {
            // Arrange
            var visualization = new MockILabelVisualization();

            var fieldName = "TestField";
            var expectedLabels = new DimensionColumn()
            {
                DataField = new TextDataField(fieldName)
            };

            // Act
            visualization.SetLabel(fieldName);

            // Assert
            Assert.Equivalent(expectedLabels, visualization.Label);
        }

        [Fact]
        public void SetLabel_UpdateLabel_WithDimensionDataField()
        {
            // Arrange
            var visualization = new MockILabelVisualization();

            var mockDimensionDataField = new Mock<DimensionDataField>("TestDataField");
            var field = mockDimensionDataField.Object;
            var expectedLabels = new DimensionColumn()
            {
                DataField = field
            };

            // Act
            visualization.SetLabel(field);

            // Assert
            Assert.Equivalent(expectedLabels, visualization.Label);
        }

        private class MockILabelVisualization : ILabel
        {
            public DimensionColumn Label { get; set; }
        }
    }
}
