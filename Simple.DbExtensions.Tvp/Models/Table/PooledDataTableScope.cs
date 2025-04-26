using Simple.DbExtensions.Tvp.Models.Contracts;

using System;
using System.Collections.Generic;

namespace Simple.DbExtensions.Tvp.Models.Table
{
    public readonly ref struct PooledDataTableScope<TRow> : IDisposable where TRow : class, ITableValued
    {
        /// <summary>
        /// 
        /// </summary>
        public PooledDataTable Table
        {
            get;
            private init;
        }

        /// <inheritdoc/>
        public readonly void Dispose()
        {
            Table.Return<TRow>();
        }

        public PooledDataTableScope(IEnumerable<TRow> rows)
        {
            Table = rows.Build();
        }

        public PooledDataTableScope(TRow row)
        {
            Table = row.Build();
        }
    }
}