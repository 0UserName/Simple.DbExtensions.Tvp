using Simple.DbExtensions.Tvp.Metadata.Contracts;

using System;
using System.Data;

using System.Diagnostics;

namespace Simple.DbExtensions.Tvp.Metadata
{
    [DebuggerDisplay("Name = { Name }, Type = { Type }, Ordinal = { Ordinal }")]
    public class ColumnInternalMetadata(string name, Type type, int ordinal) : IColumnInternalMetadata
    {
        /// <inheritdoc/>
        public string Name
        {
            get => name;
        }

        /// <inheritdoc/>
        public Type Type
        {
            get => type;
        }

        /// <inheritdoc/>
        public int Ordinal
        {
            get => ordinal;
        }

        /// <inheritdoc/>
        public virtual DataColumn CreateColumn()
        {
            return new DataColumn(name, type);
        }
    }
}