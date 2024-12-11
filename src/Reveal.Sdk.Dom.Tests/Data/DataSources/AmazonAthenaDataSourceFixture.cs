using Newtonsoft.Json.Linq;
using Reveal.Sdk.Dom.Core.Extensions;
using Reveal.Sdk.Dom.Data;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data.DataSources
{
    public class AmazonAthenaDataSourceFixture
    {
        [Fact]
        public void Constructor_SetsProviderToAmazonAthena_NoConditions()
        {
            // Act
            var dataSource = new AmazonAthenaDataSource();

            // Assert
            Assert.Equal(DataSourceProvider.AmazonAthena, dataSource.Provider);
        }

        [Fact]
        public void GetDataCatalog_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new AmazonAthenaDataSource();
            var expectedDataCatalog = "TestCatalog";

            // Act
            dataSource.DataCatalog = expectedDataCatalog;

            // Assert
            Assert.Equal(expectedDataCatalog, dataSource.DataCatalog);
            Assert.Equal(expectedDataCatalog, dataSource.Properties.GetValue<string>("dataCatalog"));
        }

        [Fact]
        public void GetOutputLocation_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new AmazonAthenaDataSource();
            var expectedOutputLocation = "s3://test-bucket/output/";

            // Act
            dataSource.OutputLocation = expectedOutputLocation;

            // Assert
            Assert.Equal(expectedOutputLocation, dataSource.OutputLocation);
            Assert.Equal(expectedOutputLocation, dataSource.Properties.GetValue<string>("outputLocation"));
        }

        [Fact]
        public void GetRegion_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new AmazonAthenaDataSource();
            var expectedRegion = "us-west-2";

            // Act
            dataSource.Region = expectedRegion;

            // Assert
            Assert.Equal(expectedRegion, dataSource.Region);
            Assert.Equal(expectedRegion, dataSource.Properties.GetValue<string>("region"));
        }

        [Fact]
        public void GetWorkgroup_ReturnSameValue_WithSetValue()
        {
            // Arrange
            var dataSource = new AmazonAthenaDataSource();
            var expectedWorkgroup = "primary";

            // Act
            dataSource.Workgroup = expectedWorkgroup;

            // Assert
            Assert.Equal(expectedWorkgroup, dataSource.Workgroup);
            Assert.Equal(expectedWorkgroup, dataSource.Properties.GetValue<string>("workgroup"));
        }

        [Fact]
        public void ToJsonString_HaveSameObject_WithRevealJson()
        {
            // Arrange
            var expectedJson = """
            {
              "_type": "DataSourceType",
              "Id": "athenaDSId",
              "Provider": "AMAZON_ATHENA",
              "Description": "Athena",
              "Properties": {
                "region": "us-east-1",
                "Database": "mydatabase",
                "outputLocation": "s3://athena-bucket/Test",
                "dataCatalog": "TestCatalog",
                "workgroup": "TestWG"
              }
            }
            """;
            var dataSource = new AmazonAthenaDataSource()
            {
                Id = "athenaDSId",
                Title = "Athena",
                Region = "us-east-1",
                Database = "mydatabase",
                DataCatalog = "TestCatalog",
                Workgroup = "TestWG",
                OutputLocation = "outputLocation"
            };

            // Act
            var json = dataSource.ToJsonString();
            var expectedJObject = JObject.Parse(expectedJson);
            var actualJObject = JObject.Parse(json);

            // Assert
            Assert.Equal(expectedJObject, actualJObject);
        }
    }
}