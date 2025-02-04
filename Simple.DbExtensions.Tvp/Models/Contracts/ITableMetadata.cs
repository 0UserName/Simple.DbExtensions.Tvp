using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface ITableMetadata
    {
        /// <summary>
        /// Name of the table type.
        /// </summary>
        string Name
        {
            get;
        }

        /// <inheritdoc cref="DataTable.CaseSensitive"/>
        bool CaseSensitive
        {
            get;
        }
    }
}