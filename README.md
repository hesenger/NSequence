# NSequence

A dead simple HiLo sequence generator to be used like `Guid.NewGuid`.

## Why a static helper instead of DI?

The intent is to have a static method available to be used in the same way
we use Guid.NewGuid(). The main intent here is to be able to generate unique
identifiers in business objects (likely aggregates and entities) without
having to inject a service or repository.

## Usage

```csharp
// initialized once at application startup
var connectionProvider = new SqlServerDatabaseProvider();
SequenceGenerator.ConnectionProvider = connectionProvider;

// static method can be used anywhere in the business layer
var id = SequenceGenerator.Next("Person");
```

## Running the tests

Since the HiLo sequences are stored in a Sql Database we need to have
an instance available, you can easily spin up a docker and run tests
using the following commands:

```bash
make startdb
make test
```
