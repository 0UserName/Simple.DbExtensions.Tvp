using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Attributes;

using Simple.DbExtensions.Tvp.Models.Contracts;
using Simple.DbExtensions.Tvp.Models.Table;

using System.Reflection;

namespace Simple.DbExtensions.Tvp.Pools
{
    internal sealed class TableValuedPool<TRow> : DefaultObjectPool<PooledDataTable> where TRow : class, ITableValued
    {
        /// <summary>
        /// Retrieves a shared <see cref="TableValuedPool{TRow}"/> instance.
        /// </summary>
        public static readonly
            TableValuedPool<TRow> Shared = new
            TableValuedPool<TRow>
            ();

        private TableValuedPool() : base(new TableValuedObjectPolicy<TRow>(), TRow.Type.GetCustomAttribute<TableValuedPoolAttribute>()?.MaximumRetained ?? 50)
        { }
    }
}