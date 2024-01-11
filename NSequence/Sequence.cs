namespace NSequence;

public class Sequence
{
    private readonly IDbConnectionProvider _connectionProvider;
    private readonly string _sequenceName;
    private int MaxLo = 100;
    private int _currentLo;
    private int _currentHi;

    public Sequence(IDbConnectionProvider connectionProvider, string sequenceName)
    {
        _connectionProvider = connectionProvider;
        _sequenceName = sequenceName;
        _currentLo = 0;
        _currentHi = GetNextHi();
    }

    public int Next()
    {
        lock (this)
        {
            if (_currentLo == MaxLo - 1)
            {
                _currentLo = 0;
                _currentHi = GetNextHi();
            }
            else
            {
                _currentLo++;
            }

            return _currentHi * MaxLo + _currentLo;
        }
    }

    private int GetNextHi()
    {
        using var connection = _connectionProvider.GetConnection();
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = """
            DECLARE @id int;
            SELECT @id = NextHi FROM HiLo WHERE SequenceName = @sequenceName;
            
            IF @id IS NULL BEGIN
                INSERT INTO HiLo (SequenceName, NextHi) VALUES (@sequenceName, 1);
                SELECT @id = 1;
            END

            UPDATE HiLo SET NextHi = @id + 1;

            SELECT @id;
            """;

        var parameter = command.CreateParameter();
        parameter.ParameterName = "@sequenceName";
        parameter.Value = _sequenceName;
        command.Parameters.Add(parameter);

        return (int)command.ExecuteScalar()!;
    }
}
