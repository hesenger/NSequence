using NSequence;

namespace Tests;

[Collection("SqlServerCollection")]
public class SequenceShould
{
    [Fact]
    public void GenerateUniqueSequencialNumbers()
    {
        var connectionProvider = new SqlServerDatabaseProvider();
        var sequence = new Sequence(connectionProvider, "Person");

        var list = new List<int>();
        for (var i = 1; i <= 5000; i++)
            list.Add(sequence.Next());

        list.Count.ShouldBe(5000);
        list.Distinct().Count().ShouldBe(5000);
    }
}
