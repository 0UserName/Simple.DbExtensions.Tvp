using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Models.Contracts;
using Simple.DbExtensions.Tvp.Models.Table;

namespace Simple.DbExtensions.Tvp.Pools
{
    internal sealed class TableValuedObjectPolicy<TRow> : IPooledObjectPolicy<PooledDataTable> where TRow : class, ITableValued
    {
        /// <inheritdoc/>
        public PooledDataTable Create()
        {
            return new PooledDataTable(TRow.Table, TRow.Columns);
        }

        /// <inheritdoc/>
        public bool Return(PooledDataTable obj)
        {
            return obj.TryReset();
        }
    }
}