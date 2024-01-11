using System.Data;

namespace NSequence;

public interface IDbConnectionProvider
{
    IDbConnection GetConnection();
}
