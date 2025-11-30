using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Metadata.Contracts;
using Simple.DbExtensions.Tvp.Parameters.Contracts;

namespace Simple.DbExtensions.Tvp.Pools
{
    internal sealed class ParameterPool<TRow, TParameter> : DefaultObjectPool<TParameter> where TRow : class, ITableValued where TParameter : class, IPoolableParameter
    {
        /// <summary>
        /// Retrieves a shared <see cref="ParameterPool{TRow, TParameter}"/> instance.
        /// </summary>
        public static readonly
            ParameterPool<TRow, TParameter> Shared = new
            ParameterPool<TRow, TParameter>
            ();

        private ParameterPool() : base(new ParameterObjectPolicy<TRow, TParameter>(), TRow.Table.MaximumRetained)
        { }
    }
}