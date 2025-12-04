using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Metadata.Contracts;
using Simple.DbExtensions.Tvp.Parameters.Contracts;
using Simple.DbExtensions.Tvp.Pools;

using System.Collections.Generic;
using System.Data;

namespace Simple.DbExtensions.Tvp.Parameters
{
    internal sealed class ParameterDataDT<TRow> : DataTable, IParameter<TRow> where TRow : class, ITableValued
    {
        private readonly ObjectPool<ParameterDataDT<TRow>> _pool;

        /// <summary>
        /// Gets 
        /// all of the values for 
        /// this instance through 
        /// an array.
        /// </summary>
        private RentedBuffer<object> GetRow(TRow row)
        {
            RentedBuffer<object> buffer = new
            RentedBuffer<object>
            (Columns.Count);

            for (int i = 0; i < Columns.Count; i++)
            {
                buffer.Segment.Array[i] = row.GetValue<object>(i);
            }

            return buffer;
        }

        /// <inheritdoc/>
        public void LoadDataRow(IEnumerable<TRow> rows)
        {
            BeginLoadData();

            foreach (TRow row in rows)
            {
                using (RentedBuffer<object> buffer = GetRow(row))
                {
                    using (buffer.EnterToUnsafeResizeScope(TRow.Columns.Length))
                    {
                        LoadDataRow(buffer.Segment.Array, LoadOption.PreserveChanges);
                    }
                }
            }

            EndLoadData();
        }

        /// <inheritdoc/>
        public bool TryReset()
        {
            Clear();

            return true;
        }

        /// <inheritdoc/>
        public void Return()
        {
            _pool.Return(this);
        }

        public ParameterDataDT(ObjectPool<ParameterDataDT<TRow>> pool) : base(TRow.Table.Name)
        {
            _pool = pool;

            BeginInit();

            foreach (IColumnInternalMetadata metadata in TRow.Columns)
            {
                Columns.Add(metadata.CreateColumn());
            }

            EndInit();
        }
    }
}