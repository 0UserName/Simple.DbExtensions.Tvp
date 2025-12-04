using Microsoft.Data.SqlClient;

using Npgsql;
using Npgsql.Tvp;

using Simple.DbExtensions.Tvp.Metadata.Abstracts;
using Simple.DbExtensions.Tvp.Metadata.Attributes;

using Simple.DbExtensions.Tvp.Parameters;
using Simple.DbExtensions.Tvp.Parameters.Contracts;

using System.Data;
using System.Data.Common;

IPoolableParameter TVP = new TVP[]
{
    new TVP{ Property1 = true, Property2 = 1, Property3 = 1, Property5 = "startString_423434543544532432_endString", Property6 = default },
    new TVP{ Property1 = true, Property2 = 2, Property3 = 2, Property5 = "text", Property6 = 6 }

}.Build(true);

NpgsqlDataSourceBuilder builder = new NpgsqlDataSourceBuilder("Host=localhost;Username=postgres;Password=root;Database=postgres");

builder.UseTvp();

NpgsqlDataSource dataSource = builder.Build();

DbConnection connection = dataSource.CreateConnection();

// SqlConnection connection = new
// SqlConnection
// ("data source=WINDOWS-OCLCPS2;initial catalog=Test;trusted_connection=true;Encrypt=false");

await connection.OpenAsync();

NpgsqlParameter parameter = new
NpgsqlParameter
();

//parameter.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType..STR = SqlDbType.Structured;
parameter.ParameterName = "@params";
parameter.Value = TVP;


DbCommand command = connection.CreateCommand();

command.CommandText = "dbo.inserttvp";
command.CommandType = CommandType.StoredProcedure;
command.Parameters.Add(parameter);

await command.ExecuteNonQueryAsync();

TVP.Return();


[Table("dbo.tableValued", 0)]
public class TVP : AbstractTableValued<TVP>
{
    public bool Property1
    {
        get;
        set;
    }

    public int Property2
    {
        get;
        set;
    }

    public long Property3
    {
        get;
        set;
    }

    public string Property5
    {
        get;
        set;
    }

    public int? Property6
    {
        get;
        set;
    }
}