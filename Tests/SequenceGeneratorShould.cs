using NSequence;

namespace Tests;

[Collection("SqlServerCollection")]
public class SequenceGeneratorShould
{
    [Fact]
    public void Next_ThrowsException_WhenConnectionProviderIsNull()
    {
        SequenceGenerator.ConnectionProvider = null;
        Assert.Throws<InvalidOperationException>(() => SequenceGenerator.Next("test"));
    }

    [Fact]
    public void GenerateUniqueSequencialNumbers()
    {
        var connectionProvider = new SqlServerDatabaseProvider();
        SequenceGenerator.ConnectionProvider = connectionProvider;

        SequenceGenerator.Next("Person").ShouldBeGreaterThan(0);
    }
}
