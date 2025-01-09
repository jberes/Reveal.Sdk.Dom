using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Visualizations.Primitives
{
    public class VisualizationLinkerFixture
    {
        [Fact]
        public void Constructor_SetDefaultValues_WithoutTitleAndDashboard()
        {
            // Act
            var instance = new DashboardLink();

            // Assert
            Assert.Null(instance.Title);
            Assert.Null(instance.Dashboard);
            Assert.Equal(LinkType.OpenDashboard, instance.Type);
        }

        [Fact]
        public void Constructor_SetDefaultValues_WithTitleAndDashboard()
        {
            // Arrange
            var title = "My Dashboard";
            var dashboard = "Dashboard";

            // Act
            var instance = new DashboardLink(title, dashboard);

            // Assert
            Assert.Equal(title, instance.Title);
            Assert.Equal(dashboard, instance.Dashboard);
            Assert.Equal(LinkType.OpenDashboard, instance.Type);
        }

        [Fact]
        public void ToJsonString_CreateCorrectJsonString_WithoutCondition()
        {
            // Arrange
            var expectedJson = """
            {
              "Url": "Dashboard",
              "Parameters": [],
              "Title": "My Dashboard",
              "Type": "OpenDashboard"
            }
            """;

            var instance = new DashboardLink("My Dashboard", "Dashboard");

            // Act
            var actualJson = instance.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(actualJson);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}
