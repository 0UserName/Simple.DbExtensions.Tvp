using Simple.DbExtensions.Tvp.Models.Contracts;

using System.Collections.Generic;

namespace Simple.DbExtensions.Tvp.Models.Table
{
    public static class PooledDataTableScopeExtension
    {
        /// <summary>
        /// 
        /// </summary>
        public static PooledDataTableScope<TRow> BuildScoped<TRow>(this IEnumerable<TRow> rows) where TRow : class, ITableValued
        {
            return new PooledDataTableScope<TRow>(rows);
        }

        /// <summary>
        /// 
        /// </summary>
        public static PooledDataTableScope<TRow> BuildScoped<TRow>(this TRow row) where TRow : class, ITableValued
        {
            return new PooledDataTableScope<TRow>(row);
        }
    }
}