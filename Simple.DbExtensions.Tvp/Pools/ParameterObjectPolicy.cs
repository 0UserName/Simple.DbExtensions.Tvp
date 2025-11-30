using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Metadata.Contracts;
using Simple.DbExtensions.Tvp.Parameters.Contracts;

using System;

namespace Simple.DbExtensions.Tvp.Pools
{
    internal sealed class ParameterObjectPolicy<TRow, TParameter> : IPooledObjectPolicy<TParameter> where TRow : class, ITableValued where TParameter : class, IPoolableParameter
    {
        /// <inheritdoc/>
        public TParameter Create()
        {
            return (TParameter)Activator.CreateInstance(typeof(TParameter), ParameterPool<TRow, TParameter>.Shared);
        }

        /// <inheritdoc/>
        public bool Return(TParameter obj)
        {
            return obj.TryReset();
        }
    }
}