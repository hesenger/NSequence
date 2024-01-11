# NSequence

A dead simple HiLo sequence generator.

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
