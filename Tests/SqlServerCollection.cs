namespace Tests;

[CollectionDefinition("SqlServerCollection")]
public class SqlServerCollection : ICollectionFixture<SqlServerFixture> { }

public class SqlServerFixture
{
    public SqlServerFixture()
    {
        CreateHiLoTable();
    }

    private void CreateHiLoTable()
    {
        using var connection = new SqlServerDatabaseProvider().GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "IF OBJECT_ID('HiLo', 'U') IS NOT NULL DROP TABLE HiLo";
        command.ExecuteNonQuery();

        command.CommandText =
            @"
            CREATE TABLE HiLo
            (
                SequenceName VARCHAR(50) PRIMARY KEY,
                NextHi INT NOT NULL,
            )";
        command.ExecuteNonQuery();
    }
}
