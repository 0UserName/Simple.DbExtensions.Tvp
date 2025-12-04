using Simple.DbExtensions.Tvp.Metadata.Attributes;
using Simple.DbExtensions.Tvp.Metadata.Contracts;

using Simple.DbExtensions.Tvp.Storages;

using System;
using System.Data;

using System.Reflection;

namespace Simple.DbExtensions.Tvp.Metadata.Abstracts
{
    public abstract class AbstractTableValued<TRow> : ITableValued where TRow : class, ITableValued
    {
        /// <inheritdoc/>
        public static Type Type
        {
            get => typeof(TRow);
        }

        /// <inheritdoc/>
        public static ITableMetadata Table
        {
            get;
            private set;

        } = Type.GetCustomAttribute<TableAttribute>();

        /// <inheritdoc/>
        public static IColumnInternalMetadata[] Columns
        {
            get;
            private set;

        } = Sort(MetadataStorage.GetColumns<TRow>());

        /// <inheritdoc/>
        public static DataTable Schema
        {
            get;
            private set;

        } = CreateSchema();

        private static IColumnInternalMetadata[] Sort(IColumnInternalMetadata[] metadata)
        {
            Array.Sort(metadata, (x, y) => x.Ordinal.CompareTo(y.Ordinal));

            return metadata;
        }

        private static DataTable CreateSchema()
        {
            DataTable table = new
            DataTable
            (Table.Name);

            foreach (IColumnInternalMetadata column in Columns)
            {
                table.Columns.Add(column.CreateColumn());
            }

            return new DataTableReader(table).GetSchemaTable();
        }

        /// <inheritdoc/>
        public T GetValue<T>(int ordinal)
        {
            return (T)Type.GetProperty(Columns[ordinal].Name).GetValue(this);
        }
    }
}