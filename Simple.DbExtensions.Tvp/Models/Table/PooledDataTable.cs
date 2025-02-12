using Microsoft.Extensions.ObjectPool;

using Simple.DbExtensions.Tvp.Models.Contracts;

using System.Collections.Generic;
using System.Data;

namespace Simple.DbExtensions.Tvp.Models.Table
{
    public sealed class PooledDataTable : DataTable, IResettable
    {
        private void InitColumns(IColumnMetadata[] metadata)
        {
            for (int i = 0; i < metadata.Length; i++)
            {
                Columns.Add(metadata[i].CreateColumn());
            }
        }

        /// <summary>
        /// Finds and updates
        /// a specific row. If no matching row is 
        /// found, a new row is created using the 
        /// given values.
        /// </summary>
        public void LoadDataRow<TRow>(IEnumerable<TRow> rows) where TRow : class, ITableValued
        {
            BeginLoadData();

            foreach (TRow row in rows)
            {
                LoadDataRow(row.GetRow(), LoadOption.PreserveChanges);
            }

            EndLoadData();
        }

        /// <inheritdoc/>
        public bool TryReset()
        {
            Clear();

            return true;
        }

        internal PooledDataTable(ITableMetadata table, IColumnMetadata[] columns) : base(table.Name)
        {
            BeginInit();

            CaseSensitive = table.CaseSensitive;

            InitColumns(columns);

            EndInit();
        }
    }
}