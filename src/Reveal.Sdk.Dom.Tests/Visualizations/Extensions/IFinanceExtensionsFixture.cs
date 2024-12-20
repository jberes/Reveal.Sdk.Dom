using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Extensions
{
    public class IFinanceExtensionsFixture
    {
        [Fact]
        public void SetOpen_UpdateOpen_WithFieldName()
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Opens = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };
            var fieldName = "TestFieldName";
            var field = new NumberDataField(fieldName);
            field.Formatting = new NumberFormatting()
            {
                DecimalDigits = 0,
                ShowGroupingSeparator = true
            };
            var expectedOpen = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetOpen(fieldName);

            // Assert
            Assert.Equivalent(expectedOpen, visualization.Opens);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetOpen_UpdateOpen_WithNumberDataField(bool isFormattingNull)
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Opens = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };

            var fieldFormat = isFormattingNull ? null : new NumberFormatting()
            {
                DecimalDigits = 2,
                ShowGroupingSeparator = false
            };
            var field = new NumberDataField("TestField")
            {
                Formatting = fieldFormat
            };

            var expectedOpen = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetOpen(field);

            // Assert
            Assert.Equivalent(expectedOpen, visualization.Opens);
        }

        [Fact]
        public void SetClose_UpdateClose_WithFieldName()
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Closes = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };
            var fieldName = "TestFieldName";
            var field = new NumberDataField(fieldName);
            field.Formatting = new NumberFormatting()
            {
                DecimalDigits = 0,
                ShowGroupingSeparator = true
            };
            var expectedClose = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetClose(fieldName);

            // Assert
            Assert.Equivalent(expectedClose, visualization.Closes);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetClose_UpdateClose_WithNumberDataField(bool isFormattingNull)
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Closes = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };

            var fieldFormat = isFormattingNull ? null : new NumberFormatting()
            {
                DecimalDigits = 2,
                ShowGroupingSeparator = false
            };
            var field = new NumberDataField("TestField")
            {
                Formatting = fieldFormat
            };

            var expectedClose = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetClose(field);

            // Assert
            Assert.Equivalent(expectedClose, visualization.Closes);
        }

        [Fact]
        public void SetHigh_UpdateHigh_WithFieldName()
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Highs = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };
            var fieldName = "TestFieldName";
            var field = new NumberDataField(fieldName);
            field.Formatting = new NumberFormatting()
            {
                DecimalDigits = 0,
                ShowGroupingSeparator = true
            };
            var expectedHigh = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetHigh(fieldName);

            // Assert
            Assert.Equivalent(expectedHigh, visualization.Highs);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetHigh_UpdateHigh_WithNumberDataField(bool isFormattingNull)
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Highs = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };

            var fieldFormat = isFormattingNull ? null : new NumberFormatting()
            {
                DecimalDigits = 2,
                ShowGroupingSeparator = false
            };
            var field = new NumberDataField("TestField")
            {
                Formatting = fieldFormat
            };

            var expectedHigh = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetHigh(field);

            // Assert
            Assert.Equivalent(expectedHigh, visualization.Highs);
        }

        [Fact]
        public void SetLow_UpdateLow_WithFieldName()
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Lows = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };
            var fieldName = "TestFieldName";
            var field = new NumberDataField(fieldName);
            field.Formatting = new NumberFormatting()
            {
                DecimalDigits = 0,
                ShowGroupingSeparator = true
            };
            var expectedLow = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetLow(fieldName);

            // Assert
            Assert.Equivalent(expectedLow, visualization.Lows);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void SetLow_UpdateLow_WithNumberDataField(bool isFormattingNull)
        {
            // Arrange
            var visualization = new MockIFiananceVisualization() { Lows = new List<MeasureColumn>() { new MeasureColumn() { DataField = new NumberDataField("InitialField") } } };

            var fieldFormat = isFormattingNull ? null : new NumberFormatting()
            {
                DecimalDigits = 2,
                ShowGroupingSeparator = false
            };
            var field = new NumberDataField("TestField")
            {
                Formatting = fieldFormat
            };

            var expectedLow = new List<MeasureColumn> { new MeasureColumn() { DataField = field } };

            // Act
            visualization.SetLow(field);

            // Assert
            Assert.Equivalent(expectedLow, visualization.Lows);
        }


        private class MockIFiananceVisualization : IFinance
        {
            public List<MeasureColumn> Opens { get; set; } = new List<MeasureColumn>();

            public List<MeasureColumn> Highs { get; set; } = new List<MeasureColumn>();

            public List<MeasureColumn> Lows { get; set; } = new List<MeasureColumn>();

            public List<MeasureColumn> Closes { get; set; } = new List<MeasureColumn>();
        }
    }
}
