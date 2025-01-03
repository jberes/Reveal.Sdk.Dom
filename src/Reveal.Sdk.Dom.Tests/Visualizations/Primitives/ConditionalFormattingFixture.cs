using Newtonsoft.Json;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class ConditionalFormattingFixture
    {
        [Fact]
        public void Constructor_SetDefaultBounds_WhenCreated()
        {
            // Arrange
            var expectedMinimum = new Bound() { ValueType = BoundValueType.LowestValue };
            var expectedMaximum = new Bound() { ValueType = BoundValueType.HighestValue };

            // Act
            var conditionalFormatting = new ConditionalFormatting();

            // Assert
            Assert.Equivalent(expectedMinimum, conditionalFormatting.Minimum);
            Assert.Equivalent(expectedMaximum, conditionalFormatting.Maximum);
        }
    }
}
