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
    public class ILabelsExtensions
    {
        [Fact]
        public void SetLabel_UpdateLabels_WithFieldName()
        {
            // Arrange
            var mockLabel = new Mock<ILabels>();
            mockLabel.Setup(x => x.Labels).Returns(new List<DimensionColumn> { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockLabel.Object;

            var fieldName = "TestName";
            var expectedLabels = new List<DimensionColumn> { new DimensionColumn() { DataField = new TextDataField(fieldName) } };

            // Act
            visualization.SetLabel(fieldName);

            // Assert
            Assert.Equivalent(expectedLabels, visualization.Labels);
        }

        [Fact]
        public void SetLabel_UpdateLabels_WithDimensionDataField()
        {
            // Arrange
            var mockLabel = new Mock<ILabels>();
            mockLabel.Setup(x => x.Labels).Returns(new List<DimensionColumn> { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockLabel.Object;

            var mockDimensionDataField = new Mock<DimensionDataField>("TestField");
            var dimensionDataField = mockDimensionDataField.Object;
            var expectedLabels = new List<DimensionColumn> { new DimensionColumn() { DataField = dimensionDataField } };

            // Act
            visualization.SetLabel(dimensionDataField);

            // Assert
            Assert.Equivalent(expectedLabels, visualization.Labels);
        }

        [Fact]
        public void SetLabels_UpdateLabels_WithListFieldNames()
        {
            // Arrange
            var mockLabel = new Mock<ILabels>();
            mockLabel.Setup(x => x.Labels).Returns(new List<DimensionColumn> { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockLabel.Object;

            var listFieldNames = new List<string>
            {
                "FirstField",
                "SecondField"
            };
            var expectedLabels = listFieldNames.Select(fieldName => new DimensionColumn()
            {
                DataField = new TextDataField(fieldName)
            }).ToList();

            // Act
            visualization.SetLabels(listFieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedLabels, visualization.Labels);
        }

        [Fact]
        public void SetLabels_UpdateLabels_WithListDimensionDateFields()
        {
            // Arrange
            var mockLabel = new Mock<ILabels>();
            mockLabel.Setup(x => x.Labels).Returns(new List<DimensionColumn> { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockLabel.Object;

            var listFields = new List<DimensionDataField>();
            var expectedLabels = new List<DimensionColumn>();

            var mockDimensionDataField1 = new Mock<DimensionDataField>("FirstField");
            var firstField = mockDimensionDataField1.Object;
            listFields.Add(firstField);
            expectedLabels.Add(new DimensionColumn(firstField));

            var mockDimensionDataField2 = new Mock<DimensionDataField>("SecondField");
            var secondField = mockDimensionDataField2.Object;
            listFields.Add(secondField);
            expectedLabels.Add(new DimensionColumn(secondField));

            // Act
            visualization.SetLabels(listFields.ToArray());

            // Assert
            Assert.Equivalent(expectedLabels, visualization.Labels);
        }
    }
}
