using Microsoft.Data.SqlClient;

namespace HealthClinic.Connection
{
    // DBConnection class manages database connectivity.
    // It provides a reusable SQL connection to different service classes.
    public static class DBConnection
    {
        // Connection string used to connect with SQL Server database.
        private static readonly string connectionString =
            @"Server=localhost\SQLEXPRESS;
              Database=Health_Clinic;
              Trusted_Connection=True;
              Encrypt=False;
              TrustServerCertificate=True;";


        // Returns an open SQL connection object.
        // Service classes will use this method whenever database access is required.
        public static SqlConnection GetConnection()
        {
            SqlConnection connection =
                new SqlConnection(connectionString);

            return connection;
        }
    }
}