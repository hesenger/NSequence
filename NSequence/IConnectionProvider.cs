using System.Data;

namespace NSequence;

public interface IConnectionProvider
{
    IDbConnection GetConnection();
}
