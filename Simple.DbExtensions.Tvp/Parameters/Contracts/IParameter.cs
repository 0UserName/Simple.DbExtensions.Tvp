using Simple.DbExtensions.Tvp.Metadata.Contracts;

using System.Collections.Generic;

namespace Simple.DbExtensions.Tvp.Parameters.Contracts
{
    internal interface IParameter<in TRow> : IPoolableParameter where TRow : class, ITableValued
    {
        void LoadDataRow(IEnumerable<TRow> rows);
    }
}