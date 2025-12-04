using Simple.DbExtensions.Tvp.Metadata.Contracts;
using Simple.DbExtensions.Tvp.Parameters.Contracts;
using Simple.DbExtensions.Tvp.Pools;

using System.Collections.Generic;

namespace Simple.DbExtensions.Tvp.Parameters
{
    public static class ParameterExtension
    {
        /// <summary>
        /// Creates a table-valued parameter 
        /// for passing to stored procedures.
        /// </summary>
        public static IPoolableParameter Build<TRow>(this IEnumerable<TRow> rows, bool useDataTable = true) where TRow : class, ITableValued
        {
            IParameter<TRow> parameter = useDataTable ?
                ParameterPool<TRow, ParameterDataDT<TRow>>.Shared.Get() :
                ParameterPool<TRow, ParameterDataDR<TRow>>.Shared.Get();

            try
            {
                parameter.LoadDataRow(rows);
            }
            catch
            {
                parameter.Return();

                throw;
            }

            return parameter;
        }

        /// <inheritdoc cref="Build{TRow}(IEnumerable{TRow}, bool)"/>
        public static IPoolableParameter Build<TRow>(this TRow row, bool useDataTable = default) where TRow : class, ITableValued
        {
            using (RentedBuffer<TRow> buffer = new
                   RentedBuffer<TRow>
                   (row))
            {
                return buffer.Segment.Build(useDataTable);
            }
        }
    }
}