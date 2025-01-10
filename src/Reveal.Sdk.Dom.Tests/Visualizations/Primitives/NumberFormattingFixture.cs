using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Constants;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class NumberFormattingFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WhenConstructed()
        {
            // Act
            var instance = new NumberFormatting();

            // Assert
            Assert.Equal(SchemaTypeNames.NumberFormattingSpecType, instance.SchemaTypeName);
            Assert.Equal("$", instance.CurrencySymbol);
            Assert.Equal(2, instance.DecimalDigits);
            Assert.Equal(NumberFormattingType.Number, instance.FormatType);
            Assert.Equal(NegativeFormatType.MinusSign, instance.NegativeFormat);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "_type": "NumberFormattingSpecType",
              "ApplyMkFormat": false,
              "CurrencySymbol": "€",
              "DecimalDigits": 4,
              "FormatType": "Currency",
              "NegativeFormat": "Parenthesis",
              "ShowGroupingSeparator": false,
              "OverrideDefaultSettings": false
            }
            """;

            var instance = new NumberFormatting();
            instance.DecimalDigits = 4;
            instance.CurrencySymbol = "€";
            instance.FormatType = NumberFormattingType.Currency;
            instance.NegativeFormat = NegativeFormatType.Parenthesis;

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
