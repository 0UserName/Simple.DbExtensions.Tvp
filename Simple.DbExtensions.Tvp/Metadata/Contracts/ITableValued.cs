using System;
using System.Data;
using System.Data.Common;

namespace Simple.DbExtensions.Tvp.Metadata.Contracts
{
    public interface ITableValued
    {
        static abstract Type Type
        {
            get;
        }

        /// <summary>
        /// Metadata for a table type 
        /// previously created on the 
        /// server.
        /// </summary>
        static abstract ITableMetadata Table
        {
            get;
        }

        /// <summary>
        /// Metadata for each column of a
        /// table type previously created
        /// on the server.
        /// </summary>
        static abstract IColumnInternalMetadata[] Columns
        {
            get;
        }

        /// <inheritdoc cref="Columns"/>
        /// 
        /// <remarks>
        /// Used for parameters inheriting from <see cref="DbDataReader"/>.
        /// </remarks>
        static abstract DataTable Schema
        {
            get;
        }

        /// <summary>
        /// Gets 
        /// the value of the 
        /// specified column.
        /// </summary>
        T GetValue<T>(int ordinal);
    }
}