using Microsoft.Data.SqlClient;

namespace Connection
{
    public class DBConnection
    {
        private static readonly string connectionString =
            "Server=localhost\\SQLEXPRESS;" +
            "Database=HealthcareDB;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;";

        // Returns CLOSED connection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
