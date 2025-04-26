using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Contracts
{
    public interface IColumnInternalMetadata
    {
        /// <inheritdoc cref="DataColumn.ColumnName"/>
        string Name
        {
            get;
        }

        /// <inheritdoc cref="DataColumn.DataType"/>
        string Type
        {
            get;
        }

        /// <inheritdoc cref="DataColumn.Ordinal"/>
        int Ordinal
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        DataColumn CreateColumn();
    }
}