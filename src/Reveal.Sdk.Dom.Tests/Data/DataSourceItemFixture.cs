using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Reveal.Sdk.Dom.Tests.Data
{
    public class DataSourceItemFixture
    {
        [Fact]
        public void DataSourceItem_Id_DefaultValue()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();

            // Act

            // Assert
            Assert.NotEmpty(dataSourceItem.Id);
        }

        [Fact]
        public void DataSourceItem_Id_SetValue()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var id = "12345";

            // Act
            dataSourceItem.Id = id;

            // Assert
            Assert.Equal(id, dataSourceItem.Id);
        }

        [Fact]
        public void DataSourceItem_Title_SetValue()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var title = "Test Title";

            // Act
            dataSourceItem.Title = title;

            // Assert
            Assert.Equal(title, dataSourceItem.Title);
        }

        [Fact]
        public void DataSourceItem_Subtitle_SetValue()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var subtitle = "Test Subtitle";

            // Act
            dataSourceItem.Subtitle = subtitle;

            // Assert
            Assert.Equal(subtitle, dataSourceItem.Subtitle);
        }

        [Fact]
        public void DataSourceItem_Fields_SetValue()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var fields = new List<IField> { new TextField() };

            // Act
            dataSourceItem.Fields = fields;

            // Assert
            Assert.Equal(fields, dataSourceItem.Fields);
        }

        [Fact]
        public void DataSourceItem_DataSource_SetValue()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var dataSource = new DataSource();

            // Act
            dataSourceItem.DataSource = dataSource;

            // Assert
            Assert.Equal(dataSource, dataSourceItem.DataSource);
        }

        [Fact]
        public void DataSourceItem_Join_AddsJoinTable()
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var joinConditions = new List<JoinCondition> { new JoinCondition("left", "right") };
            var dataSourceItemToJoin = new DataSourceItem();

            // Act
            dataSourceItem.Join("Alias", joinConditions, dataSourceItemToJoin);

            // Assert
            Assert.Single(dataSourceItem.JoinTables);
            Assert.Equal("Alias", dataSourceItem.JoinTables[0].Alias);
            Assert.Equal(dataSourceItemToJoin, dataSourceItem.JoinTables[0].DataDefinition.DataSourceItem);
            Assert.Single(dataSourceItem.JoinTables[0].JoinConditions);
            Assert.Equal("[left]", dataSourceItem.JoinTables[0].JoinConditions[0].LeftFieldName);
            Assert.Equal("Alias.[right]", dataSourceItem.JoinTables[0].JoinConditions[0].RightFieldName);
        }

        [Theory]
        [InlineData("FieldName", "[FieldName]")]
        [InlineData("[FieldName]", "[FieldName]")]
        [InlineData("A.FieldName", "A.[FieldName]")]
        [InlineData("A.[FieldName]", "A.[FieldName]")]
        public void ValidateLeftJoinFieldName_ShouldReturnFormattedFieldName(string fieldName, string expected)
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var joinConditions = new List<JoinCondition> { new JoinCondition(fieldName, "") };
            var dataSourceItemToJoin = new DataSourceItem();

            // Act
            dataSourceItem.Join("Alias", joinConditions, dataSourceItemToJoin);

            // Assert
            Assert.Equal(expected, dataSourceItem.JoinTables[0].JoinConditions[0].LeftFieldName);
        }

        [Theory]
        [InlineData("FieldName")]
        [InlineData("[FieldName]")]
        [InlineData("Alias.FieldName")]
        [InlineData("Alias.[FieldName]")]
        public void ValidateRightFieldName_ShouldReturnFormattedFieldName(string fieldName)
        {
            // Arrange
            var dataSourceItem = new DataSourceItem();
            var joinConditions = new List<JoinCondition> { new JoinCondition("", fieldName) };
            var dataSourceItemToJoin = new DataSourceItem();

            // Act
            dataSourceItem.Join("Alias", joinConditions, dataSourceItemToJoin);

            // Assert
            Assert.Equal("Alias.[FieldName]", dataSourceItem.JoinTables[0].JoinConditions[0].RightFieldName);
        }

        [Theory]
        [InlineData(typeof(AmazonAthenaDataSourceItem), false)]
        [InlineData(typeof(AmazonRedshiftDataSourceItem), false)]
        [InlineData(typeof(AmazonS3DataSourceItem), false)]
        [InlineData(typeof(BoxDataSourceItem), false)]
        [InlineData(typeof(DropboxDataSourceItem), false)]
        [InlineData(typeof(ExcelFileDataSourceItem), false)]
        [InlineData(typeof(GoogleAnalytics4DataSourceItem), false)]
        [InlineData(typeof(GoogleBigQueryDataSourceItem), false)]
        [InlineData(typeof(GoogleDriveDataSourceItem), false)]
        [InlineData(typeof(GoogleSheetsDataSourceItem), false)]
        [InlineData(typeof(MicrosoftAnalysisServicesDataSourceItem), true)]
        [InlineData(typeof(MicrosoftAzureAnalysisServicesDataSourceItem), true)]
        [InlineData(typeof(MicrosoftAzureSqlDatabaseDataSourceItem), false)]
        [InlineData(typeof(MicrosoftAzureSynapseAnalyticsDataSourceItem), false)]
        [InlineData(typeof(MicrosoftOneDriveDataSourceItem), false)]
        [InlineData(typeof(MicrosoftSharePointDataSourceItem), false)]
        [InlineData(typeof(MicrosoftSqlServerDataSourceItem), false)]
        [InlineData(typeof(MongoDbDataSourceItem), false)]
        [InlineData(typeof(MySqlDataSourceItem), false)]
        [InlineData(typeof(ODataDataSourceItem), false)]
        [InlineData(typeof(OracleDataSourceItem), false)]
        [InlineData(typeof(PostgreSqlDataSourceItem), false)]
        [InlineData(typeof(RestDataSourceItem), false)]
        [InlineData(typeof(SnowflakeDataSourceItem), false)]
        [InlineData(typeof(WebServiceDataSourceItem), false)]
        public void DataSourceItem_IsXmla(Type dataSourceItemType, bool expectedIsXmla)
        {
            // Arrange
            var constructor = dataSourceItemType.GetConstructor(new[] { typeof(string), typeof(DataSource) });
            var dataSourceItem = (DataSourceItem)constructor.Invoke(new object[] { null, null });

            // Act
            var isXmla = dataSourceItem.IsXmla;

            // Assert
            Assert.Equal(expectedIsXmla, isXmla);
        }
    }
}
