using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using Reveal.Sdk.Dom.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class TabularColumnFixture
    {
        [Fact]
        public void Constructor_SetDefaultBands_WhenConstructed()
        {
            // Arrange
            var expectedUpper = new TestBand() { Color = BandColor.Green, Value = 80.0 };
            var expectedMiddle = new TestBand() { Color = BandColor.Yellow, Value = 50.0 };
            var expectedLower = new TestBand() { Color = BandColor.Red };

            var expectedBands = new List<TestBand>()
            {
                expectedUpper,
                expectedMiddle,
                expectedLower
            };

            // Act
            var item = new TestConditionalFormattingBase();

            // Assert
            Assert.Equivalent(expectedBands, item.Bands);
            Assert.Equivalent(expectedUpper, item.UpperBand);
            Assert.Equivalent(expectedMiddle, item.MiddleBand);
            Assert.Equivalent(expectedLower, item.LowerBand);
        }

        [Fact]
        public void SetValueComparisonType_SetAllBandsValues_WhenCalled()
        {
            // Arrange
            var item = new TestConditionalFormattingBase();
            var expectedValueComparisonType = ValueComparisonType.Number;

            // Act
            item.ValueComparisonType = expectedValueComparisonType;

            // Assert
            foreach (var band in item.Bands)
            {
                Assert.Equal(expectedValueComparisonType, band.ValueComparisonType);
            }
        }

        [Fact]
        public void GetValueComparisonType_ReturnFirstBandValue_WhenCalled()
        {
            // Arrange
            var item = new TestConditionalFormattingBase();
            var expectedValueComparisonType = item.Bands.First().ValueComparisonType;

            // Act
            var result = item.ValueComparisonType;

            // Assert
            Assert.Equal(expectedValueComparisonType, result);
        }

        private class TestConditionalFormattingBase : ConditionalFormattingBase<TestBand>
        {
        }

        private class TestBand: Band
        {
        }
    }
}