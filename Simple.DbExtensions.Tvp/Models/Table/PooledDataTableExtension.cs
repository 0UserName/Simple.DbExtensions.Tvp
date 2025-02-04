using Simple.DbExtensions.Tvp.Models.Contracts;
using Simple.DbExtensions.Tvp.Pools;

using System;
using System.Collections.Generic;

namespace Simple.DbExtensions.Tvp.Models.Table
{
    public static class PooledDataTableExtension
    {
        /// <summary>
        /// Creates a table-valued parameter 
        /// suitable for passing to a stored 
        /// procedure.
        /// </summary>
        public static PooledDataTable Build<TRow>(this IEnumerable<TRow> rows) where TRow : class, ITableValued
        {
            PooledDataTable table = TableValuedPool<TRow>.Shared.Get();

            try
            {
                table.LoadDataRow(rows);
            }
            catch (Exception)
            {
                table.Return<TRow>();

                throw;
            }

            return table;
        }

        /// <inheritdoc cref="Build{TRow}(IEnumerable{TRow})"/>
        public static PooledDataTable Build<TRow>(this TRow row) where TRow : class, ITableValued
        {
            return ThreadStaticArrayPool<TRow>.Rent(1, row).Build();
        }

        /// <summary>
        /// Return the table to the pool.
        /// </summary>
        public static void Return<TRow>(this PooledDataTable table) where TRow : class, ITableValued
        {
            TableValuedPool<TRow>.Shared.Return(table);
        }
    }
}