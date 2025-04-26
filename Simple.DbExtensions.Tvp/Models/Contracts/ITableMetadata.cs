using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface ITableMetadata
    {
        /// <inheritdoc cref="DataTable.TableName"/>
        string Name
        {
            get;
        }
    }
}