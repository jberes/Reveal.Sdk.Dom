# Data Type Mapping for Auto-Generated Visualizations

When automatically generating dashboards from database schemas or API responses, correctly mapping data types to Reveal field types is crucial for proper visualization and analysis. This guide provides comprehensive patterns for mapping common data types to Reveal DOM field types.

## Core Mapping Concepts

Reveal.Sdk.Dom supports several field types for different data scenarios:

- **TextField**: String/text data, categorical values
- **NumberField**: Numeric data for calculations and aggregations  
- **DateField**: Date, datetime, and timestamp values
- **CalculatedField**: Custom formulas and computed values

## Database Type Mapping Utilities

### SQL Server Data Type Mapper

Based on real-world patterns from enterprise applications:

```csharp
using Reveal.Sdk.Dom.Data;
using System.Data;

public static class SqlServerTypeMapper
{
    public static string MapSqlDataTypeToRevealDataType(string sqlDataType)
    {
        return sqlDataType.ToUpper() switch
        {
            // String types
            "CHAR" or "VARCHAR" or "NCHAR" or "NVARCHAR" or "TEXT" or "NTEXT" 
                or "XML" or "UNIQUEIDENTIFIER" => "String",
            
            // Numeric types
            "TINYINT" or "SMALLINT" or "INT" or "BIGINT" or "DECIMAL" or "NUMERIC"
                or "FLOAT" or "REAL" or "MONEY" or "SMALLMONEY" => "Number",
            
            // Date/Time types  
            "DATE" or "DATETIME" or "DATETIME2" or "SMALLDATETIME" or "DATETIMEOFFSET" => "Date",
            "TIME" => "Time",
            
            // Boolean types
            "BIT" => "Boolean",
            
            // Binary types (treat as string for display)
            "BINARY" or "VARBINARY" or "IMAGE" => "String",
            
            // Default fallback
            _ => "String"
        };
    }

    public static IField CreateRevealField(string columnName, string sqlDataType, 
        bool isNullable = false, int? maxLength = null)
    {
        var revealType = MapSqlDataTypeToRevealDataType(sqlDataType);
        
        return revealType switch
        {
            "Number" => new NumberField(columnName) 
            { 
                FieldLabel = FormatFieldLabel(columnName),
                Description = CreateFieldDescription(columnName, sqlDataType, maxLength, isNullable)
            },
            "Date" => new DateField(columnName) 
            { 
                FieldLabel = FormatFieldLabel(columnName),
                Description = CreateFieldDescription(columnName, sqlDataType, maxLength, isNullable)
            },
            "Boolean" => new TextField(columnName) 
            { 
                FieldLabel = FormatFieldLabel(columnName),
                Description = CreateFieldDescription(columnName, sqlDataType, maxLength, isNullable)
            },
            _ => new TextField(columnName) 
            { 
                FieldLabel = FormatFieldLabel(columnName),
                Description = CreateFieldDescription(columnName, sqlDataType, maxLength, isNullable)
            }
        };
    }

    private static string FormatFieldLabel(string columnName)
    {
        // Convert snake_case or PascalCase to friendly labels
        return string.Join(" ", columnName
            .Replace("_", " ")
            .Split(' ')
            .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
    }

    private static string CreateFieldDescription(string columnName, string dataType, 
        int? maxLength, bool isNullable)
    {
        var parts = new List<string> { dataType };
        
        if (maxLength.HasValue && maxLength > 0)
            parts.Add($"({maxLength})");
            
        if (!isNullable)
            parts.Add("NOT NULL");
            
        return string.Join(" ", parts);
    }
}
```

### PostgreSQL Data Type Mapper

For PostgreSQL databases, based on real query builder applications:

```csharp
public static class PostgreSqlTypeMapper
{
    public static string MapPostgresDataTypeToRevealDataType(string dataType)
    {
        return dataType.ToLower() switch
        {
            // String types
            "character varying" or "varchar" or "char" or "character" or "text" 
                or "uuid" or "json" or "jsonb" or "xml" => "String",
            
            // Numeric types
            "smallint" or "integer" or "int" or "int4" or "bigint" or "int8"
                or "smallserial" or "serial" or "serial4" or "bigserial" or "serial8" => "Number",
            "numeric" or "decimal" or "real" or "float4" or "double precision" 
                or "float8" or "money" => "Number",
            
            // Date/Time types
            "date" or "timestamp" or "timestamp without time zone" 
                or "timestamp with time zone" or "timestamptz" => "Date",
            "time" or "time without time zone" or "time with time zone" => "Time",
            
            // Boolean types
            "boolean" or "bool" => "Boolean",
            
            // Array and other types (treat as string for display)
            _ when dataType.EndsWith("[]") => "String",
            "bytea" or "bit" or "varbit" or "inet" or "cidr" or "macaddr" => "String",
            
            // Default fallback
            _ => "String"
        };
    }

    public static List<IField> MapColumnsToRevealFields(ColumnMetadata[] columns)
    {
        var result = new List<IField>();
        
        foreach (var col in columns)
        {
            var field = col.RevealDataType switch
            {
                "Number" => CreateNumberField(col),
                "Date" => CreateDateField(col),
                "Time" => CreateTimeField(col),
                "Boolean" => CreateBooleanField(col),
                _ => CreateTextField(col)
            };
            
            result.Add(field);
        }
        
        return result;
    }

    private static NumberField CreateNumberField(ColumnMetadata col)
    {
        return new NumberField(col.ColumnName)
        {
            FieldLabel = FormatFieldLabel(col.ColumnName),
            Description = $"Numeric field ({col.DataType})"
        };
    }

    private static DateField CreateDateField(ColumnMetadata col)
    {
        return new DateField(col.ColumnName)
        {
            FieldLabel = FormatFieldLabel(col.ColumnName),
            Description = $"Date/Time field ({col.DataType})"
        };
    }

    private static DateField CreateTimeField(ColumnMetadata col)
    {
        // Time fields are typically handled as DateField in Reveal
        return new DateField(col.ColumnName)
        {
            FieldLabel = FormatFieldLabel(col.ColumnName),
            Description = $"Time field ({col.DataType})"
        };
    }

    private static TextField CreateBooleanField(ColumnMetadata col)
    {
        // Boolean fields are often displayed as text for filtering
        return new TextField(col.ColumnName)
        {
            FieldLabel = FormatFieldLabel(col.ColumnName),
            Description = $"Boolean field ({col.DataType})"
        };
    }

    private static TextField CreateTextField(ColumnMetadata col)
    {
        return new TextField(col.ColumnName)
        {
            FieldLabel = FormatFieldLabel(col.ColumnName),
            Description = $"Text field ({col.DataType})"
        };
    }

    private static string FormatFieldLabel(string columnName)
    {
        return SqlServerTypeMapper.FormatFieldLabel(columnName);
    }
}

public record ColumnMetadata(
    string ColumnName,
    string DataType,
    string RevealDataType
);
```

## REST API Data Type Mapping

For JSON APIs and web services, infer types from data samples:

```csharp
using System.Text.Json;

public static class JsonTypeMapper
{
    public static List<IField> InferFieldsFromJsonSample(JsonElement sample)
    {
        var fields = new List<IField>();
        
        if (sample.ValueKind != JsonValueKind.Object)
            return fields;

        foreach (var property in sample.EnumerateObject())
        {
            var field = InferFieldFromJsonProperty(property.Name, property.Value);
            if (field != null)
                fields.Add(field);
        }

        return fields;
    }

    private static IField? InferFieldFromJsonProperty(string propertyName, JsonElement value)
    {
        return value.ValueKind switch
        {
            JsonValueKind.String => InferFromStringValue(propertyName, value.GetString()),
            JsonValueKind.Number => new NumberField(propertyName) 
            { 
                FieldLabel = FormatFieldLabel(propertyName) 
            },
            JsonValueKind.True or JsonValueKind.False => new TextField(propertyName) 
            { 
                FieldLabel = FormatFieldLabel(propertyName) 
            },
            JsonValueKind.Array => new TextField(propertyName) 
            { 
                FieldLabel = FormatFieldLabel(propertyName),
                Description = "Array field (serialized as text)"
            },
            JsonValueKind.Object => new TextField(propertyName) 
            { 
                FieldLabel = FormatFieldLabel(propertyName),
                Description = "Object field (serialized as text)"
            },
            _ => null
        };
    }

    private static IField InferFromStringValue(string propertyName, string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return new TextField(propertyName) { FieldLabel = FormatFieldLabel(propertyName) };
        }

        // Try to parse as date
        if (DateTime.TryParse(value, out _) || 
            DateTimeOffset.TryParse(value, out _))
        {
            return new DateField(propertyName) { FieldLabel = FormatFieldLabel(propertyName) };
        }

        // Try to parse as number (sometimes JSON APIs return numbers as strings)
        if (decimal.TryParse(value, out _))
        {
            return new NumberField(propertyName) { FieldLabel = FormatFieldLabel(propertyName) };
        }

        // Default to text
        return new TextField(propertyName) { FieldLabel = FormatFieldLabel(propertyName) };
    }

    private static string FormatFieldLabel(string propertyName)
    {
        // Convert camelCase/PascalCase to friendly labels
        return System.Text.RegularExpressions.Regex.Replace(propertyName, 
            @"(?<!^)([A-Z])", " $1");
    }
}
```

## Excel/CSV Data Type Inference

For Excel and CSV file imports:

```csharp
public static class ExcelTypeMapper
{
    public static List<IField> InferFieldsFromDataTable(DataTable dataTable)
    {
        var fields = new List<IField>();

        foreach (DataColumn column in dataTable.Columns)
        {
            var field = MapDataColumnToField(column, dataTable);
            fields.Add(field);
        }

        return fields;
    }

    private static IField MapDataColumnToField(DataColumn column, DataTable dataTable)
    {
        var columnName = column.ColumnName;
        var dataType = column.DataType;

        // Check actual data for better type inference
        var sampleValues = GetNonNullSampleValues(dataTable, columnName, 10);

        if (IsNumericType(dataType) || AllValuesAreNumeric(sampleValues))
        {
            return new NumberField(columnName)
            {
                FieldLabel = FormatFieldLabel(columnName),
                Description = $"Numeric data (inferred from {dataType.Name})"
            };
        }

        if (IsDateTimeType(dataType) || AllValuesAreDates(sampleValues))
        {
            return new DateField(columnName)
            {
                FieldLabel = FormatFieldLabel(columnName),
                Description = $"Date/Time data (inferred from {dataType.Name})"
            };
        }

        if (IsBooleanType(dataType) || AllValuesAreBoolean(sampleValues))
        {
            return new TextField(columnName)
            {
                FieldLabel = FormatFieldLabel(columnName),
                Description = $"Boolean data (inferred from {dataType.Name})"
            };
        }

        return new TextField(columnName)
        {
            FieldLabel = FormatFieldLabel(columnName),
            Description = $"Text data (inferred from {dataType.Name})"
        };
    }

    private static List<object> GetNonNullSampleValues(DataTable dataTable, string columnName, int maxSamples)
    {
        return dataTable.AsEnumerable()
            .Where(row => !row.IsNull(columnName))
            .Take(maxSamples)
            .Select(row => row[columnName])
            .ToList();
    }

    private static bool IsNumericType(Type type)
    {
        return type == typeof(int) || type == typeof(long) || type == typeof(decimal) ||
               type == typeof(double) || type == typeof(float) || type == typeof(short) ||
               type == typeof(byte);
    }

    private static bool IsDateTimeType(Type type)
    {
        return type == typeof(DateTime) || type == typeof(DateTimeOffset) ||
               type == typeof(DateOnly) || type == typeof(TimeOnly);
    }

    private static bool IsBooleanType(Type type)
    {
        return type == typeof(bool);
    }

    private static bool AllValuesAreNumeric(List<object> values)
    {
        if (values.Count == 0) return false;
        return values.All(v => decimal.TryParse(v?.ToString(), out _));
    }

    private static bool AllValuesAreDates(List<object> values)
    {
        if (values.Count == 0) return false;
        return values.All(v => DateTime.TryParse(v?.ToString(), out _));
    }

    private static bool AllValuesAreBoolean(List<object> values)
    {
        if (values.Count == 0) return false;
        return values.All(v => bool.TryParse(v?.ToString(), out _));
    }

    private static string FormatFieldLabel(string columnName)
    {
        return SqlServerTypeMapper.FormatFieldLabel(columnName);
    }
}
```

## Complete Auto-Generation Example

Here's a comprehensive example that combines type mapping with dashboard generation:

```csharp
using Reveal.Sdk.Dom;
using Reveal.Sdk.Dom.Data;
using Reveal.Sdk.Dom.Visualizations;
using Microsoft.Data.SqlClient;

public class AutoDashboardGenerator
{
    public async Task<RdashDocument> GenerateTableDashboardAsync(
        string connectionString, 
        string tableName, 
        string dashboardTitle)
    {
        // 1. Get table schema and data types
        var columns = await GetTableSchemaAsync(connectionString, tableName);
        
        // 2. Create dashboard document
        var document = new RdashDocument(dashboardTitle)
        {
            Description = $"Auto-generated dashboard for table: {tableName}",
            Theme = Theme.MountainLight
        };

        // 3. Create data source
        var dataSource = new MicrosoftSqlServerDataSource()
        {
            Title = "Auto-Generated Source",
            // Connection details would be configured via providers
        };

        // 4. Create data source item with mapped fields
        var fields = columns.Select(col => 
            SqlServerTypeMapper.CreateRevealField(col.ColumnName, col.DataType, col.IsNullable, col.MaxLength)
        ).ToList();

        var dataSourceItem = new MicrosoftSqlServerDataSourceItem($"{tableName} Data", tableName, dataSource)
        {
            Table = tableName,
            Fields = fields
        };

        // 5. Create visualizations based on data types
        CreateVisualizationsForTable(document, dataSourceItem, columns);

        return document;
    }

    private void CreateVisualizationsForTable(
        RdashDocument document, 
        DataSourceItem dataSourceItem, 
        List<ColumnInfo> columns)
    {
        var numericColumns = columns.Where(c => IsNumeric(c.DataType)).ToList();
        var dateColumns = columns.Where(c => IsDate(c.DataType)).ToList();
        var textColumns = columns.Where(c => IsText(c.DataType)).ToList();

        // 1. Always create a grid for raw data
        var grid = new GridVisualization("Data Grid", dataSourceItem)
        {
            Title = "All Data",
            ColumnSpan = 6,
            RowSpan = 4
        };
        grid.SetColumns(columns.Select(c => c.ColumnName).ToArray());
        document.Visualizations.Add(grid);

        // 2. Create charts for numeric data
        if (numericColumns.Count > 0)
        {
            CreateNumericCharts(document, dataSourceItem, numericColumns, textColumns);
        }

        // 3. Create date-based charts if date columns exist
        if (dateColumns.Count > 0 && numericColumns.Count > 0)
        {
            CreateTimeSeriesCharts(document, dataSourceItem, dateColumns, numericColumns);
        }

        // 4. Create categorical breakdowns
        if (textColumns.Count > 0 && numericColumns.Count > 0)
        {
            CreateCategoricalCharts(document, dataSourceItem, textColumns, numericColumns);
        }
    }

    private void CreateNumericCharts(
        RdashDocument document,
        DataSourceItem dataSourceItem,
        List<ColumnInfo> numericColumns,
        List<ColumnInfo> textColumns)
    {
        foreach (var numericCol in numericColumns.Take(3)) // Limit to first 3 numeric columns
        {
            // KPI for individual metrics
            var kpi = new KpiVisualization($"{numericCol.ColumnName} KPI", dataSourceItem)
            {
                Title = $"Total {FormatLabel(numericCol.ColumnName)}",
                ColumnSpan = 2,
                RowSpan = 2
            };
            kpi.SetValue(numericCol.ColumnName, AggregationType.Sum);
            document.Visualizations.Add(kpi);

            // Bar chart if there's a categorical column
            if (textColumns.Count > 0)
            {
                var barChart = new BarChartVisualization($"{numericCol.ColumnName} by Category", dataSourceItem)
                {
                    Title = $"{FormatLabel(numericCol.ColumnName)} by {FormatLabel(textColumns[0].ColumnName)}",
                    ColumnSpan = 4,
                    RowSpan = 3
                };
                barChart.SetLabel(textColumns[0].ColumnName);
                barChart.SetValue(numericCol.ColumnName, AggregationType.Sum);
                document.Visualizations.Add(barChart);
            }
        }
    }

    private void CreateTimeSeriesCharts(
        RdashDocument document,
        DataSourceItem dataSourceItem,
        List<ColumnInfo> dateColumns,
        List<ColumnInfo> numericColumns)
    {
        var dateCol = dateColumns.First();
        var numericCol = numericColumns.First();

        var lineChart = new LineChartVisualization("Time Series", dataSourceItem)
        {
            Title = $"{FormatLabel(numericCol.ColumnName)} Over Time",
            ColumnSpan = 6,
            RowSpan = 3
        };
        
        lineChart.SetLabel(dateCol.ColumnName);
        lineChart.SetValue(numericCol.ColumnName, AggregationType.Sum);
        
        document.Visualizations.Add(lineChart);
    }

    private void CreateCategoricalCharts(
        RdashDocument document,
        DataSourceItem dataSourceItem,
        List<ColumnInfo> textColumns,
        List<ColumnInfo> numericColumns)
    {
        var categoryCol = textColumns.First();
        var valueCol = numericColumns.First();

        var pieChart = new PieChartVisualization("Category Breakdown", dataSourceItem)
        {
            Title = $"{FormatLabel(valueCol.ColumnName)} by {FormatLabel(categoryCol.ColumnName)}",
            ColumnSpan = 3,
            RowSpan = 3
        };
        
        pieChart.SetLabel(categoryCol.ColumnName);
        pieChart.SetValue(valueCol.ColumnName, AggregationType.Sum);
        
        document.Visualizations.Add(pieChart);
    }

    private async Task<List<ColumnInfo>> GetTableSchemaAsync(string connectionString, string tableName)
    {
        var columns = new List<ColumnInfo>();

        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        var query = @"
            SELECT 
                COLUMN_NAME,
                DATA_TYPE,
                IS_NULLABLE,
                CHARACTER_MAXIMUM_LENGTH
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = @TableName
            ORDER BY ORDINAL_POSITION";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@TableName", tableName);

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            columns.Add(new ColumnInfo
            {
                ColumnName = reader.GetString("COLUMN_NAME"),
                DataType = reader.GetString("DATA_TYPE"),
                IsNullable = reader.GetString("IS_NULLABLE") == "YES",
                MaxLength = reader.IsDBNull("CHARACTER_MAXIMUM_LENGTH") ? 
                    null : reader.GetInt32("CHARACTER_MAXIMUM_LENGTH")
            });
        }

        return columns;
    }

    private static bool IsNumeric(string dataType) => 
        SqlServerTypeMapper.MapSqlDataTypeToRevealDataType(dataType) == "Number";

    private static bool IsDate(string dataType) => 
        SqlServerTypeMapper.MapSqlDataTypeToRevealDataType(dataType) == "Date";

    private static bool IsText(string dataType) => 
        SqlServerTypeMapper.MapSqlDataTypeToRevealDataType(dataType) == "String";

    private static string FormatLabel(string columnName) => 
        SqlServerTypeMapper.FormatFieldLabel(columnName);
}

public class ColumnInfo
{
    public string ColumnName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public bool IsNullable { get; set; }
    public int? MaxLength { get; set; }
}
```

## Best Practices

### 1. Handle Edge Cases

```csharp
public static class TypeMappingBestPractices
{
    public static IField CreateRobustField(string columnName, string dataType, 
        object[] sampleValues = null)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(columnName))
            throw new ArgumentException("Column name cannot be empty", nameof(columnName));

        // Clean column name for Reveal compatibility
        var cleanColumnName = CleanColumnName(columnName);
        var fieldLabel = FormatFieldLabel(columnName);

        // Use sample data to improve type inference
        if (sampleValues?.Length > 0)
        {
            var inferredType = InferTypeFromSamples(sampleValues);
            if (!string.IsNullOrEmpty(inferredType))
            {
                return CreateFieldByType(cleanColumnName, fieldLabel, inferredType);
            }
        }

        // Fall back to schema-based mapping
        var mappedType = MapDataType(dataType);
        return CreateFieldByType(cleanColumnName, fieldLabel, mappedType);
    }

    private static string CleanColumnName(string columnName)
    {
        // Remove invalid characters, ensure Reveal compatibility
        var cleaned = new string(columnName.Where(c => 
            char.IsLetterOrDigit(c) || c == '_').ToArray());
        
        // Ensure it starts with a letter or underscore
        if (!string.IsNullOrEmpty(cleaned) && char.IsDigit(cleaned[0]))
            cleaned = "_" + cleaned;
            
        return string.IsNullOrEmpty(cleaned) ? "UnknownField" : cleaned;
    }

    private static string InferTypeFromSamples(object[] samples)
    {
        var nonNullSamples = samples.Where(s => s != null).Take(10).ToArray();
        
        if (nonNullSamples.Length == 0) return "String";

        // Check if all samples are numeric
        if (nonNullSamples.All(s => IsNumeric(s.ToString())))
            return "Number";

        // Check if all samples are dates
        if (nonNullSamples.All(s => IsDate(s.ToString())))
            return "Date";

        return "String";
    }

    private static bool IsNumeric(string value) =>
        decimal.TryParse(value, out _) || double.TryParse(value, out _);

    private static bool IsDate(string value) =>
        DateTime.TryParse(value, out _) || DateTimeOffset.TryParse(value, out _);
}
```

### 2. Performance Optimization

```csharp
public class CachedTypeMapper
{
    private static readonly Dictionary<string, string> TypeMappingCache = new();
    private static readonly object CacheLock = new object();

    public static string GetMappedType(string dataType)
    {
        if (TypeMappingCache.TryGetValue(dataType, out var cachedType))
            return cachedType;

        lock (CacheLock)
        {
            if (!TypeMappingCache.ContainsKey(dataType))
            {
                var mappedType = SqlServerTypeMapper.MapSqlDataTypeToRevealDataType(dataType);
                TypeMappingCache[dataType] = mappedType;
                return mappedType;
            }
            return TypeMappingCache[dataType];
        }
    }
}
```

### 3. Custom Type Extensions

```csharp
public static class CustomTypeMappers
{
    public static IField CreateGeoField(string columnName, string dataType)
    {
        // For geographic data, treat as text but add special metadata
        return new TextField(columnName)
        {
            FieldLabel = FormatFieldLabel(columnName),
            Description = $"Geographic data ({dataType}) - Consider using map visualizations"
        };
    }

    public static IField CreateCurrencyField(string columnName, string dataType)
    {
        // For currency, use NumberField with appropriate formatting
        return new NumberField(columnName)
        {
            FieldLabel = FormatFieldLabel(columnName),
            Description = $"Currency field ({dataType}) - Values represent monetary amounts"
        };
    }
}
```

## Troubleshooting Common Issues

1. **Null/Empty Values**: Always check for null values when inferring types from data samples
2. **Mixed Data Types**: Use the most permissive type (usually TextField) for columns with mixed data
3. **Large Text Fields**: Consider truncation strategies for very long text values
4. **Special Characters**: Sanitize column names to ensure Reveal compatibility
5. **Performance**: Cache type mappings for frequently accessed schemas
6. **Locale Considerations**: Be aware of date/number format differences in international deployments

This comprehensive approach ensures reliable data type mapping across different data sources while maintaining performance and flexibility for various visualization scenarios.