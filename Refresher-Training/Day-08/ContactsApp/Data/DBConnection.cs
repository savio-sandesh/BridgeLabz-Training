using Microsoft.Data.SqlClient;

namespace ContactsApp.Data;

/// <summary>
/// Provides database connections for the application.
/// </summary>
public class DbConnection
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="DbConnection"/> class.
    /// </summary>
    public DbConnection(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Creates a SQL connection using the configured connection string.
    /// </summary>
    public SqlConnection GetConnection()
    {
        string? connectionString =
            _configuration.GetConnectionString("ContactDbConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "ContactDbConnection connection string is not configured."
            );
        }

        return new SqlConnection(connectionString);
    }
}