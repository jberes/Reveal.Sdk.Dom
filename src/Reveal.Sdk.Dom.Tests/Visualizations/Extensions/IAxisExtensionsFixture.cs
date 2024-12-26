using Reveal.Sdk.Dom.Visualizations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IAxisExtensionsFixture
    {
        [Fact]
        public void SetXAxis_UpdateXAxis_WithFieldName()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fieldName = "TestFieldName";
            var expectedXAxes = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField(fieldName) } };

            // Act
            visualization.SetXAxis(fieldName);

            // Assert
            Assert.Equivalent(expectedXAxes, visualization.XAxes);
        }

        [Fact]
        public void SetXAxis_UpdateXAxis_WithNumberDataField()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fieldName = "TestFieldName";
            var field = new NumberDataField(fieldName);
            var expectedXAxes = new List<MeasureColumn>() { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetXAxis(field);

            // Assert
            Assert.Equivalent(expectedXAxes, visualization.XAxes);
        }

        [Fact]
        public void SetXAxes_UpdateXAxis_WithListFieldNames()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fieldNames = new List<string>()
            {
                "FirstFieldName",
                "SecondFieldName"
            };
            var expectedXAxes = fieldNames.Select(fieldName => new MeasureColumn() { DataField = new NumberDataField(fieldName) });

            // Act
            visualization.SetXAxes(fieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedXAxes, visualization.XAxes);
        }

        [Fact]
        public void SetXAxes_UpdateXAxis_WithListNumberDataFields()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fields = new List<NumberDataField>()
            {
                new NumberDataField("FirstFieldName"),
                new NumberDataField("SecondFieldName")
            };
            var expectedXAxes = fields.Select(x => new MeasureColumn() { DataField = x });

            // Act
            visualization.SetXAxes(fields.ToArray());

            // Assert
            Assert.Equivalent(expectedXAxes, visualization.XAxes);
        }

        [Fact]
        public void SetYAxis_UpdateYAxis_WithFieldName()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fieldName = "TestFieldName";
            var expectedYAxes = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField(fieldName) } };

            // Act
            visualization.SetYAxis(fieldName);

            // Assert
            Assert.Equivalent(expectedYAxes, visualization.YAxes);
        }

        [Fact]
        public void SetYAxis_UpdateYAxis_WithNumberDataField()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fieldName = "TestFieldName";
            var field = new NumberDataField(fieldName);
            var expectedYAxes = new List<MeasureColumn>() { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetYAxis(field);

            // Assert
            Assert.Equivalent(expectedYAxes, visualization.YAxes);
        }

        [Fact]
        public void SetYAxes_UpdateYAxis_WithListFieldNames()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fieldNames = new List<string>()
            {
                "FirstFieldName",
                "SecondFieldName"
            };
            var expectedYAxes = fieldNames.Select(fieldName => new MeasureColumn() { DataField = new NumberDataField(fieldName) });

            // Act
            visualization.SetYAxes(fieldNames.ToArray());

            // Assert
            Assert.Equivalent(expectedYAxes, visualization.YAxes);
        }

        [Fact]
        public void SetYAxes_UpdateYAxis_WithListNumberDataFields()
        {
            // Arrange
            var visualization = new MockIAxis();
            var fields = new List<NumberDataField>()
            {
                new NumberDataField("FirstFieldName"),
                new NumberDataField("SecondFieldName")
            };
            var expectedYAxes = fields.Select(x => new MeasureColumn() { DataField = x });

            // Act
            visualization.SetYAxes(fields.ToArray());

            // Assert
            Assert.Equivalent(expectedYAxes, visualization.YAxes);
        }

        private class MockIAxis : IAxis
        {
            public List<MeasureColumn> XAxes { get; } = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialX") } };

            public List<MeasureColumn> YAxes { get; } = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialY") } };
        }
    }
}
