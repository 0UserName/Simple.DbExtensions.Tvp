![Release workflow](https://github.com/0UserName/Simple.DbExtensions.Tvp/actions/workflows/release.yml/badge.svg)



# Motivation

The motivation for developing this library is to simplify the creation of `DataTable` and `DbDataReader` instances used as table-valued parameters when interacting with stored procedures, as well as to add a number of additional features: pooling, schema and data validation, and column trimming.



# Usage

Add a dependency on this package and create a class implementing `ITableValued`, using the built-in `AbstractTableValued` implementation or your own. Once this is done, you can create a `DataTable` or `DbDataReader` based on your class definitions:



```csharp
[Table(nameof(Row))]
public class Row : AbstractTableValued<Row>
```



```csharp
Row[] rows = new
Row[]
{
    new Row(),
    new Row(),
    new Row()
};

IPoolableParameter parameter = rows.Build(useDataTable: true);

CallSP(parameter);

parameter.Return();
```



If you are using [Dapper](https://github.com/DapperLib/Dapper), add:



```csharp
SqlMapper.AddTypeMap(typeof(IPoolableParameter<Row>), DbType.Object);
```



Or cast `IPoolableParameter` to `DataTable` or `DbDataReader`.



## Pooling

Pooling is applied at each stage of creating a `DataTable` (but not for `DataRow`). Each type has its own pool, which has a fixed size of 50. If needed, a different configuration can be specified:



```csharp
[Table(nameof(Row), 10)]
public class Row : AbstractTableValued<Row>
```



## Metadata

In the simplest case, to create a `DataTable`, only information about the columns is needed: name, type, and ordinal. By default, this information is retrieved using a bit reflection, it is also possible to load custom metadata from a database, which have a higher priority:


```csharp
MetadataStorage.AddColumns(nameof(Row), new IColumnExternalMetadata[]
{
    new ColumnExternalMetadata(table: nameof(Row), name: nameof(Row.Property0), type: typeof(int).FullName, ordinal: 1, allowDBNull: default, maxLength: -1, unique: default),
    new ColumnExternalMetadata(table: nameof(Row), name: nameof(Row.Property1), type: typeof(int).FullName, ordinal: 0, allowDBNull: default, maxLength: -1, unique: default)
});
```


`AllowDBNull`, `MaxLength`, and `Unique` are built-in constraints that are checked after all rows have been loaded into the `DataTable`. If any of these constraints are violated, a `ConstraintException` or `NoNullAllowedException` will be thrown.


> **NOTE**: If a property is not part of a table-valued parameter, it will be discarded. However, when the structure in the database is changed after the metadata has been loaded, it is assumed that the user application follow to the [Fail-fast](https://en.wikipedia.org/wiki/Fail-fast_system) approach, since updating the metadata at runtime is not possible — only at startup.


> **NOTE**: SQL script that loads metadata from the database is not included in the delivery, as no DBA would allow executing it from a third-party library due to security concerns.



# References
- [AllowDBNull](https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.allowdbnull)
- [MaxLength](https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.maxlength)
- [Ordinal](https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.ordinal)
- [Unique](https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.unique)
- [ConstraintException](https://learn.microsoft.com/ru-ru/dotnet/api/system.data.constraintexception)
- [NoNullAllowedException](https://learn.microsoft.com/ru-ru/dotnet/api/system.data.nonullallowedexception)



# Related projects

- [npgsql.tvp](https://github.com/0UserName/npgsql.tvp)