using System;
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
        Type Type
        {
            get;
        }

        /// <inheritdoc cref="DataColumn.Ordinal"/>
        int Ordinal
        {
            get;
        }

        /// <summary>
        /// Creates a column using metadata.
        /// </summary>
        DataColumn CreateColumn();
    }
}