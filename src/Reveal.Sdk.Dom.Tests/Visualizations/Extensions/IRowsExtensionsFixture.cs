using Moq;
using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IRowsExtensionsFixture
    {
        [Fact]
        public void SetRow_UpdateRows_WithFieldName()
        {
            // Arrange
            var mockRow = new Mock<IRows>();
            mockRow.Setup(s => s.Rows).Returns(new List<DimensionColumn>() { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockRow.Object;

            var fieldName = "TestField";
            var expectedRows = new List<DimensionColumn> { new DimensionColumn() { DataField = new TextDataField(fieldName) } };

            // Act
            visualization.SetRow(fieldName);

            // Assert
            Assert.Equivalent(expectedRows, visualization.Rows);
        }

        [Fact]
        public void SetRow_UpdateRows_WithDimensionDataField()
        {
            // Arrange
            var mockRow = new Mock<IRows>();
            mockRow.Setup(s => s.Rows).Returns(new List<DimensionColumn>() { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockRow.Object;

            var mockDimensionDataField = new Mock<DimensionDataField>("TestField");
            var field = mockDimensionDataField.Object;
            var expectedRows = new List<DimensionColumn> { new DimensionColumn() { DataField = field } };

            // Act
            visualization.SetRow(field);

            // Assert
            Assert.Equivalent(expectedRows, visualization.Rows);
        }

        [Fact]
        public void SetRows_UpdateRows_WithFieldNames()
        {
            // Arrange
            var mockRow = new Mock<IRows>();
            mockRow.Setup(s => s.Rows).Returns(new List<DimensionColumn>() { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockRow.Object;

            var fieldNames = new List<string>{ "FirstField", "SecondField" };
            var expectedVSRows = fieldNames.Select(fieldName => new DimensionColumn() { DataField= new TextDataField(fieldName) });

            // Act
            visualization.SetRows(fieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedVSRows, visualization.Rows);
        }

        [Fact]
        public void SetRows_UpdateRows_WithListDimensionDataFields()
        {
            // Arrange
            var mockRow = new Mock<IRows>();
            mockRow.Setup(s => s.Rows).Returns(new List<DimensionColumn>() { new DimensionColumn() { DataField = new TextDataField("InitialField") } });
            var visualization = mockRow.Object;

            var listFields = new List<DimensionDataField>();
            var expectedRows = new List<DimensionColumn>();

            var firstMockDimensionDataField = new Mock<DimensionDataField>("FirstFieldName");
            var firstField = firstMockDimensionDataField.Object;
            expectedRows.Add(new DimensionColumn() { DataField = firstField });
            listFields.Add(firstField);

            var secondMockDimensionDataField = new Mock<DimensionDataField>("SecondFieldName");
            var secondField = secondMockDimensionDataField.Object;
            expectedRows.Add(new DimensionColumn() { DataField = secondField });
            listFields.Add(secondField);

            // Act
            visualization.SetRows(listFields.ToArray());

            // Assert
            Assert.Equivalent(expectedRows, visualization.Rows);
        }
    }
}
