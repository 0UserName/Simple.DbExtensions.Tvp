using Microsoft.Extensions.ObjectPool;

namespace Simple.DbExtensions.Tvp.Parameters.Contracts
{
    public interface IPoolableParameter : IResettable
    {
        /// <inheritdoc cref="ObjectPool{TRow}.Return(TRow)"/>
        void Return();
    }
}