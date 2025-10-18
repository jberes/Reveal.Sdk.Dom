# Enterprise Data Source Management

This guide covers advanced patterns for managing data sources in enterprise environments using Reveal.Sdk.Dom. Learn how to create flexible, secure, and scalable data source architectures that support multiple databases, APIs, cloud services, and user-defined connections.

## Overview

Enterprise data source management involves:

- Multi-database connection handling with connection pooling
- Dynamic data source creation based on user context
- Secure credential management and user impersonation
- API and cloud service integration patterns
- Custom query and stored procedure execution
- Data source validation and health monitoring

## Enterprise Data Source Factory

### Comprehensive Data Source Factory

Based on real-world enterprise applications, this factory supports multiple database types and connection scenarios:

```csharp
using Reveal.Sdk.Dom.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class EnterpriseDataSourceFactory
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EnterpriseDataSourceFactory> _logger;
    private readonly ICredentialService _credentialService;
    private readonly IConnectionHealthService _healthService;

    public EnterpriseDataSourceFactory(
        IConfiguration configuration,
        ILogger<EnterpriseDataSourceFactory> logger,
        ICredentialService credentialService,
        IConnectionHealthService healthService)
    {
        _configuration = configuration;
        _logger = logger;
        _credentialService = credentialService;
        _healthService = healthService;
    }

    public async Task<DataSource> CreateDataSourceAsync(
        DataSourceRequest request, 
        UserContext userContext)
    {
        try
        {
            _logger.LogInformation("Creating data source of type {Type} for user {UserId}", 
                request.Type, userContext.UserId);

            // Validate user permissions
            await ValidateUserPermissionsAsync(request, userContext);

            var dataSource = request.Type switch
            {
                DataSourceType.SqlServer => await CreateSqlServerDataSourceAsync(request, userContext),
                DataSourceType.PostgreSQL => await CreatePostgreSQLDataSourceAsync(request, userContext),
                DataSourceType.Oracle => await CreateOracleDataSourceAsync(request, userContext),
                DataSourceType.MySQL => await CreateMySQLDataSourceAsync(request, userContext),
                DataSourceType.RestAPI => await CreateRestAPIDataSourceAsync(request, userContext),
                DataSourceType.Excel => CreateExcelDataSource(request),
                DataSourceType.AzureSqlDatabase => await CreateAzureSqlDataSourceAsync(request, userContext),
                DataSourceType.Snowflake => await CreateSnowflakeDataSourceAsync(request, userContext),
                _ => throw new NotSupportedException($"Data source type {request.Type} is not supported")
            };

            // Validate connection health
            await _healthService.ValidateConnectionAsync(dataSource, userContext);

            _logger.LogInformation("Successfully created data source {Id} for user {UserId}", 
                dataSource.Id, userContext.UserId);

            return dataSource;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create data source of type {Type} for user {UserId}", 
                request.Type, userContext.UserId);
            throw;
        }
    }

    private async Task<MicrosoftSqlServerDataSource> CreateSqlServerDataSourceAsync(
        DataSourceRequest request, 
        UserContext userContext)
    {
        var connectionConfig = await GetConnectionConfigAsync(request.ConnectionName, userContext);
        var credentials = await _credentialService.GetCredentialsAsync(request.ConnectionName, userContext);

        var dataSource = new MicrosoftSqlServerDataSource()
        {
            Id = GenerateDataSourceId(request),
            Title = request.Title ?? $"SQL Server - {connectionConfig.DatabaseName}",
            Subtitle = connectionConfig.Description,
            Host = connectionConfig.Host,
            Database = connectionConfig.DatabaseName,
            Port = connectionConfig.Port ?? 1433
        };

        // Apply security context
        ApplySecurityContext(dataSource, credentials, userContext);

        return dataSource;
    }

    private async Task<PostgreSQLDataSource> CreatePostgreSQLDataSourceAsync(
        DataSourceRequest request, 
        UserContext userContext)
    {
        var connectionConfig = await GetConnectionConfigAsync(request.ConnectionName, userContext);
        var credentials = await _credentialService.GetCredentialsAsync(request.ConnectionName, userContext);

        var dataSource = new PostgreSQLDataSource()
        {
            Id = GenerateDataSourceId(request),
            Title = request.Title ?? $"PostgreSQL - {connectionConfig.DatabaseName}",
            Subtitle = connectionConfig.Description,
            Host = connectionConfig.Host,
            Database = connectionConfig.DatabaseName,
            Port = connectionConfig.Port ?? 5432
        };

        ApplySecurityContext(dataSource, credentials, userContext);

        return dataSource;
    }

    private async Task<RestDataSource> CreateRestAPIDataSourceAsync(
        DataSourceRequest request, 
        UserContext userContext)
    {
        var apiConfig = await GetApiConfigAsync(request.ConnectionName, userContext);
        var credentials = await _credentialService.GetApiCredentialsAsync(request.ConnectionName, userContext);

        var dataSource = new RestDataSource()
        {
            Id = GenerateDataSourceId(request),
            Title = request.Title ?? $"API - {apiConfig.ServiceName}",
            Subtitle = apiConfig.Description,
            Url = apiConfig.BaseUrl
        };

        // Configure authentication
        ConfigureApiAuthentication(dataSource, credentials, apiConfig);

        return dataSource;
    }

    private ExcelDataSource CreateExcelDataSource(DataSourceRequest request)
    {
        return new ExcelDataSource()
        {
            Id = GenerateDataSourceId(request),
            Title = request.Title ?? "Excel Data Source",
            Subtitle = request.Description
        };
    }

    private void ApplySecurityContext(
        DatabaseDataSource dataSource, 
        DatabaseCredentials credentials, 
        UserContext userContext)
    {
        // Apply row-level security if configured
        if (userContext.RequiresRowLevelSecurity)
        {
            ApplyRowLevelSecurity(dataSource, userContext);
        }

        // Apply schema restrictions
        if (userContext.AllowedSchemas?.Count > 0)
        {
            ApplySchemaRestrictions(dataSource, userContext.AllowedSchemas);
        }
    }

    private void ConfigureApiAuthentication(
        RestDataSource dataSource, 
        ApiCredentials credentials, 
        ApiConfiguration config)
    {
        switch (config.AuthenticationType)
        {
            case ApiAuthenticationType.ApiKey:
                ConfigureApiKeyAuthentication(dataSource, credentials);
                break;
            case ApiAuthenticationType.OAuth2:
                ConfigureOAuth2Authentication(dataSource, credentials);
                break;
            case ApiAuthenticationType.Bearer:
                ConfigureBearerAuthentication(dataSource, credentials);
                break;
        }
    }
}
```

### Advanced Data Source Item Factory

Create data source items with intelligent field mapping and query optimization:

```csharp
public class EnterpriseDataSourceItemFactory
{
    private readonly ISchemaService _schemaService;
    private readonly IQueryOptimizer _queryOptimizer;
    private readonly IFieldMappingService _fieldMappingService;

    public async Task<DataSourceItem> CreateDataSourceItemAsync(
        DataSource dataSource,
        DataSourceItemRequest request,
        UserContext userContext)
    {
        var item = request.Type switch
        {
            DataSourceItemType.Table => await CreateTableDataSourceItemAsync(dataSource, request, userContext),
            DataSourceItemType.View => await CreateViewDataSourceItemAsync(dataSource, request, userContext),
            DataSourceItemType.StoredProcedure => await CreateProcedureDataSourceItemAsync(dataSource, request, userContext),
            DataSourceItemType.Function => await CreateFunctionDataSourceItemAsync(dataSource, request, userContext),
            DataSourceItemType.CustomQuery => await CreateCustomQueryDataSourceItemAsync(dataSource, request, userContext),
            _ => throw new NotSupportedException($"Data source item type {request.Type} is not supported")
        };

        // Apply user-specific transformations
        await ApplyUserTransformationsAsync(item, userContext);

        return item;
    }

    private async Task<TableDataSourceItem> CreateTableDataSourceItemAsync(
        DataSource dataSource,
        DataSourceItemRequest request,
        UserContext userContext)
    {
        // Get table schema with user permissions
        var schema = await _schemaService.GetTableSchemaAsync(
            dataSource, 
            request.TableName, 
            userContext);

        // Map fields with proper types
        var fields = await _fieldMappingService.MapTableFieldsAsync(schema, userContext);

        var item = new TableDataSourceItem(
            request.Title ?? FormatTableTitle(request.TableName),
            request.TableName,
            dataSource)
        {
            Id = GenerateItemId(request),
            Subtitle = request.Description ?? $"Table: {request.TableName}",
            Fields = fields
        };

        // Apply table-level filters if required
        if (userContext.RequiresDataFiltering)
        {
            await ApplyDataFiltersAsync(item, userContext);
        }

        return item;
    }

    private async Task<ProcedureDataSourceItem> CreateProcedureDataSourceItemAsync(
        DataSource dataSource,
        DataSourceItemRequest request,
        UserContext userContext)
    {
        // Get procedure metadata
        var procedureInfo = await _schemaService.GetProcedureInfoAsync(
            dataSource, 
            request.ProcedureName, 
            userContext);

        // Validate user can execute this procedure
        await ValidateProcedurePermissionsAsync(procedureInfo, userContext);

        var item = new ProcedureDataSourceItem(
            request.Title ?? FormatProcedureTitle(request.ProcedureName),
            request.ProcedureName,
            dataSource)
        {
            Id = GenerateItemId(request),
            Subtitle = request.Description ?? $"Stored Procedure: {request.ProcedureName}"
        };

        // Configure procedure parameters
        if (request.Parameters?.Count > 0)
        {
            ConfigureProcedureParameters(item, request.Parameters, userContext);
        }

        return item;
    }

    private async Task<FunctionDataSourceItem> CreateFunctionDataSourceItemAsync(
        DataSource dataSource,
        DataSourceItemRequest request,
        UserContext userContext)
    {
        var functionInfo = await _schemaService.GetFunctionInfoAsync(
            dataSource, 
            request.FunctionName, 
            userContext);

        var item = new FunctionDataSourceItem(
            request.Title ?? FormatFunctionTitle(request.FunctionName),
            request.FunctionName,
            dataSource)
        {
            Id = GenerateItemId(request),
            Subtitle = request.Description ?? $"Function: {request.FunctionName}"
        };

        // Configure function parameters
        if (request.Parameters?.Count > 0)
        {
            ConfigureFunctionParameters(item, request.Parameters, userContext);
        }

        return item;
    }

    private async Task<DataSourceItem> CreateCustomQueryDataSourceItemAsync(
        DataSource dataSource,
        DataSourceItemRequest request,
        UserContext userContext)
    {
        // Validate and optimize the custom query
        var validatedQuery = await _queryOptimizer.ValidateAndOptimizeAsync(
            request.CustomQuery, 
            userContext);

        // Analyze query to determine result schema
        var resultSchema = await _schemaService.AnalyzeQuerySchemaAsync(
            dataSource, 
            validatedQuery, 
            userContext);

        var fields = await _fieldMappingService.MapQueryFieldsAsync(resultSchema, userContext);

        var item = new DataSourceItem(
            request.Title ?? "Custom Query Result",
            dataSource)
        {
            Id = GenerateItemId(request),
            Subtitle = request.Description ?? "Custom SQL query result",
            Fields = fields
        };

        // Store the validated query for execution
        item.CustomQuery = validatedQuery;

        return item;
    }
}
```

## Multi-Cloud Data Source Integration

### Cloud Data Source Manager

Support for various cloud data services:

```csharp
public class CloudDataSourceManager
{
    private readonly IAzureCredentialService _azureCredentials;
    private readonly IAwsCredentialService _awsCredentials;
    private readonly IGcpCredentialService _gcpCredentials;

    public async Task<DataSource> CreateCloudDataSourceAsync(
        CloudDataSourceRequest request,
        UserContext userContext)
    {
        return request.CloudProvider switch
        {
            CloudProvider.Azure => await CreateAzureDataSourceAsync(request, userContext),
            CloudProvider.AWS => await CreateAwsDataSourceAsync(request, userContext),
            CloudProvider.GCP => await CreateGcpDataSourceAsync(request, userContext),
            _ => throw new NotSupportedException($"Cloud provider {request.CloudProvider} is not supported")
        };
    }

    private async Task<DataSource> CreateAzureDataSourceAsync(
        CloudDataSourceRequest request,
        UserContext userContext)
    {
        var credentials = await _azureCredentials.GetCredentialsAsync(userContext);

        return request.ServiceType switch
        {
            AzureServiceType.SqlDatabase => new MicrosoftSqlServerDataSource()
            {
                Title = $"Azure SQL - {request.DatabaseName}",
                Host = request.ServerName,
                Database = request.DatabaseName,
                Port = 1433
            },
            AzureServiceType.CosmosDb => new CosmosDbDataSource()
            {
                Title = $"Cosmos DB - {request.DatabaseName}",
                AccountEndpoint = request.CosmosEndpoint,
                Database = request.DatabaseName
            },
            AzureServiceType.DataFactory => CreateAzureDataFactorySource(request),
            AzureServiceType.Synapse => CreateAzureSynapseSource(request),
            _ => throw new NotSupportedException($"Azure service type {request.ServiceType} is not supported")
        };
    }

    private async Task<DataSource> CreateAwsDataSourceAsync(
        CloudDataSourceRequest request,
        UserContext userContext)
    {
        var credentials = await _awsCredentials.GetCredentialsAsync(userContext);

        return request.ServiceType switch
        {
            AwsServiceType.RDS => CreateAwsRdsDataSource(request, credentials),
            AwsServiceType.Redshift => CreateAwsRedshiftDataSource(request, credentials),
            AwsServiceType.Athena => CreateAwsAthenaDataSource(request, credentials),
            AwsServiceType.DynamoDB => CreateAwsDynamoDbDataSource(request, credentials),
            _ => throw new NotSupportedException($"AWS service type {request.ServiceType} is not supported")
        };
    }
}
```

## Data Source Security and Compliance

### Role-Based Data Access

Implement comprehensive security controls:

```csharp
public class SecureDataSourceService
{
    private readonly IRoleService _roleService;
    private readonly IAuditService _auditService;
    private readonly IEncryptionService _encryptionService;

    public async Task<DataSource> CreateSecureDataSourceAsync(
        DataSourceRequest request,
        UserContext userContext)
    {
        // Audit the request
        await _auditService.LogDataSourceAccessAsync(request, userContext);

        // Check user permissions
        var userRoles = await _roleService.GetUserRolesAsync(userContext.UserId);
        var requiredPermissions = GetRequiredPermissions(request);
        
        if (!HasRequiredPermissions(userRoles, requiredPermissions))
        {
            throw new UnauthorizedAccessException($"User {userContext.UserId} does not have permission to access {request.Type}");
        }

        // Create data source with security context
        var dataSource = await CreateBaseDataSourceAsync(request);

        // Apply security policies
        await ApplySecurityPoliciesAsync(dataSource, userContext);

        // Apply data masking if required
        if (await RequiresDataMaskingAsync(userContext, request))
        {
            await ApplyDataMaskingPoliciesAsync(dataSource, userContext);
        }

        return dataSource;
    }

    private async Task ApplySecurityPoliciesAsync(DataSource dataSource, UserContext userContext)
    {
        var securityPolicies = await _roleService.GetSecurityPoliciesAsync(userContext.UserId);

        foreach (var policy in securityPolicies)
        {
            switch (policy.Type)
            {
                case SecurityPolicyType.RowLevelSecurity:
                    ApplyRowLevelSecurityPolicy(dataSource, policy, userContext);
                    break;
                case SecurityPolicyType.ColumnLevelSecurity:
                    ApplyColumnLevelSecurityPolicy(dataSource, policy, userContext);
                    break;
                case SecurityPolicyType.TimeBasedAccess:
                    ValidateTimeBasedAccess(policy, userContext);
                    break;
                case SecurityPolicyType.IpRestriction:
                    ValidateIpRestriction(policy, userContext);
                    break;
            }
        }
    }

    private void ApplyRowLevelSecurityPolicy(
        DataSource dataSource, 
        SecurityPolicy policy, 
        UserContext userContext)
    {
        // Add row-level security filters based on user context
        var rlsFilter = new RowLevelSecurityFilter
        {
            FilterExpression = policy.FilterExpression.Replace("{UserId}", userContext.UserId),
            ApplyToAllTables = policy.ApplyToAllTables,
            TargetTables = policy.TargetTables
        };

        dataSource.SecurityFilters.Add(rlsFilter);
    }

    private void ApplyColumnLevelSecurityPolicy(
        DataSource dataSource, 
        SecurityPolicy policy, 
        UserContext userContext)
    {
        // Apply column masking or exclusion
        var columnPolicy = new ColumnSecurityPolicy
        {
            MaskedColumns = policy.MaskedColumns,
            ExcludedColumns = policy.ExcludedColumns,
            MaskingStrategy = policy.MaskingStrategy
        };

        dataSource.ColumnSecurityPolicies.Add(columnPolicy);
    }
}
```

## Connection Pooling and Performance

### Enterprise Connection Manager

Optimize connection management for high-performance scenarios:

```csharp
public class EnterpriseConnectionManager : IDisposable
{
    private readonly ConcurrentDictionary<string, ConnectionPool> _connectionPools;
    private readonly IConfiguration _configuration;
    private readonly ILogger<EnterpriseConnectionManager> _logger;
    private readonly Timer _healthCheckTimer;

    public EnterpriseConnectionManager(
        IConfiguration configuration,
        ILogger<EnterpriseConnectionManager> logger)
    {
        _connectionPools = new ConcurrentDictionary<string, ConnectionPool>();
        _configuration = configuration;
        _logger = logger;
        
        // Start health check timer
        _healthCheckTimer = new Timer(PerformHealthChecks, null, 
            TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
    }

    public async Task<IDbConnection> GetConnectionAsync(
        string connectionKey, 
        UserContext userContext,
        CancellationToken cancellationToken = default)
    {
        var pool = _connectionPools.GetOrAdd(connectionKey, key => CreateConnectionPool(key, userContext));
        
        return await pool.GetConnectionAsync(cancellationToken);
    }

    public async Task ReturnConnectionAsync(string connectionKey, IDbConnection connection)
    {
        if (_connectionPools.TryGetValue(connectionKey, out var pool))
        {
            await pool.ReturnConnectionAsync(connection);
        }
    }

    private ConnectionPool CreateConnectionPool(string connectionKey, UserContext userContext)
    {
        var poolConfig = _configuration.GetSection($"ConnectionPools:{connectionKey}").Get<ConnectionPoolConfig>()
            ?? new ConnectionPoolConfig();

        _logger.LogInformation("Creating connection pool for {ConnectionKey} with min={MinSize}, max={MaxSize}",
            connectionKey, poolConfig.MinPoolSize, poolConfig.MaxPoolSize);

        return new ConnectionPool(
            connectionKey,
            () => CreateConnectionAsync(connectionKey, userContext),
            poolConfig);
    }

    private async Task<IDbConnection> CreateConnectionAsync(string connectionKey, UserContext userContext)
    {
        var connectionString = await GetConnectionStringAsync(connectionKey, userContext);
        var connection = CreateDbConnection(connectionString);
        
        await connection.OpenAsync();
        
        // Apply connection-level security
        await ApplyConnectionSecurityAsync(connection, userContext);
        
        return connection;
    }

    private async Task PerformHealthChecks(object state)
    {
        foreach (var kvp in _connectionPools)
        {
            try
            {
                await kvp.Value.HealthCheckAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed for connection pool {PoolKey}", kvp.Key);
            }
        }
    }

    public void Dispose()
    {
        _healthCheckTimer?.Dispose();
        
        foreach (var pool in _connectionPools.Values)
        {
            pool.Dispose();
        }
        
        _connectionPools.Clear();
    }
}

public class ConnectionPool : IDisposable
{
    private readonly ConcurrentQueue<IDbConnection> _availableConnections;
    private readonly SemaphoreSlim _semaphore;
    private readonly Func<Task<IDbConnection>> _connectionFactory;
    private readonly ConnectionPoolConfig _config;
    private volatile int _currentPoolSize;

    public ConnectionPool(
        string poolKey,
        Func<Task<IDbConnection>> connectionFactory,
        ConnectionPoolConfig config)
    {
        _availableConnections = new ConcurrentQueue<IDbConnection>();
        _connectionFactory = connectionFactory;
        _config = config;
        _semaphore = new SemaphoreSlim(config.MaxPoolSize, config.MaxPoolSize);
    }

    public async Task<IDbConnection> GetConnectionAsync(CancellationToken cancellationToken)
    {
        await _semaphore.WaitAsync(cancellationToken);

        try
        {
            if (_availableConnections.TryDequeue(out var connection))
            {
                if (IsConnectionValid(connection))
                {
                    return connection;
                }
                else
                {
                    // Connection is invalid, create a new one
                    connection.Dispose();
                    Interlocked.Decrement(ref _currentPoolSize);
                }
            }

            // Create new connection
            connection = await _connectionFactory();
            Interlocked.Increment(ref _currentPoolSize);
            
            return connection;
        }
        catch
        {
            _semaphore.Release();
            throw;
        }
    }

    public Task ReturnConnectionAsync(IDbConnection connection)
    {
        if (IsConnectionValid(connection) && _currentPoolSize <= _config.MaxPoolSize)
        {
            _availableConnections.Enqueue(connection);
        }
        else
        {
            connection.Dispose();
            Interlocked.Decrement(ref _currentPoolSize);
        }

        _semaphore.Release();
        return Task.CompletedTask;
    }

    private bool IsConnectionValid(IDbConnection connection)
    {
        try
        {
            return connection.State == ConnectionState.Open;
        }
        catch
        {
            return false;
        }
    }

    public void Dispose()
    {
        while (_availableConnections.TryDequeue(out var connection))
        {
            connection.Dispose();
        }
        
        _semaphore.Dispose();
    }
}

public class ConnectionPoolConfig
{
    public int MinPoolSize { get; set; } = 5;
    public int MaxPoolSize { get; set; } = 50;
    public TimeSpan ConnectionTimeout { get; set; } = TimeSpan.FromSeconds(30);
    public TimeSpan IdleTimeout { get; set; } = TimeSpan.FromMinutes(30);
    public bool EnableHealthCheck { get; set; } = true;
}
```

## Best Practices

### 1. Configuration Management

```csharp
public class DataSourceConfigurationService
{
    public DataSourceConfiguration GetConfiguration(string environmentName)
    {
        return environmentName.ToLower() switch
        {
            "development" => CreateDevelopmentConfig(),
            "staging" => CreateStagingConfig(),
            "production" => CreateProductionConfig(),
            _ => throw new ArgumentException($"Unknown environment: {environmentName}")
        };
    }

    private DataSourceConfiguration CreateProductionConfig()
    {
        return new DataSourceConfiguration
        {
            EnableConnectionPooling = true,
            MaxConnectionsPerPool = 100,
            ConnectionTimeout = TimeSpan.FromSeconds(30),
            CommandTimeout = TimeSpan.FromMinutes(5),
            EnableQueryLogging = false,
            EnablePerformanceCounters = true,
            EnableSecurity = true,
            RequireEncryption = true
        };
    }
}
```

### 2. Monitoring and Metrics

```csharp
public class DataSourceMetricsCollector
{
    private readonly IMetricsLogger _metricsLogger;

    public async Task TrackDataSourceOperation(
        string operationType,
        string dataSourceType,
        TimeSpan duration,
        bool success)
    {
        await _metricsLogger.LogMetricAsync(new DataSourceMetric
        {
            OperationType = operationType,
            DataSourceType = dataSourceType,
            Duration = duration,
            Success = success,
            Timestamp = DateTime.UtcNow
        });
    }
}
```

This comprehensive approach to enterprise data source management provides the foundation for building secure, scalable, and maintainable data integration systems that can handle complex enterprise requirements while maintaining performance and security standards.