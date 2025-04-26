using Simple.DbExtensions.Tvp.Models.Contracts;

using System;
using System.Data;

using System.Diagnostics;

namespace Simple.DbExtensions.Tvp.Models
{
    [DebuggerDisplay("Name = { Name }, Type = { Type.Name }, Ordinal = { Ordinal }")]
    public class ColumnInternalMetadata : IColumnInternalMetadata
    {
        /// <inheritdoc cref="ITableMetadata.Name"/>
        public string Table
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public string Name
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public Type Type
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public int Ordinal
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public virtual DataColumn CreateColumn()
        {
            return new DataColumn(Name, Type);
        }

        public ColumnInternalMetadata(string table, string name, Type type, int ordinal)
        {
            Table = table;

            Name = name;
            Type = type;

            Ordinal = ordinal;
        }
    }
}