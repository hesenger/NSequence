namespace NSequence;

public static class SequenceGenerator
{
    public static IConnectionProvider? ConnectionProvider { get; set; }
    private static readonly Dictionary<string, Sequence> _sequences = new();

    public static int Next(string sequenceName)
    {
        if (ConnectionProvider == null)
            throw new InvalidOperationException("ConnectionProvider is not set");

        if (!_sequences.ContainsKey(sequenceName))
            _sequences.Add(sequenceName, new Sequence(ConnectionProvider, sequenceName));

        return _sequences[sequenceName].Next();
    }
}
