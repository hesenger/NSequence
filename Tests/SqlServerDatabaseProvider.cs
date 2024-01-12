using System.Data;
using Microsoft.Data.SqlClient;
using NSequence;

namespace Tests;

public class SqlServerConnectionProvider : IConnectionProvider
{
    const string ConnectionString =
        "Server=localhost;Database=master;UID=sa;PWD=DevPassword-2024;Connect Timeout=5;TrustServerCertificate=True;";

    public IDbConnection GetConnection() => new SqlConnection(ConnectionString);
}
