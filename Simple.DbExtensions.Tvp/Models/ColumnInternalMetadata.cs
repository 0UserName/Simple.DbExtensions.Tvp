using Simple.DbExtensions.Tvp.Models.Contracts;

using System;
using System.Data;

using System.Diagnostics;

namespace Simple.DbExtensions.Tvp.Models
{
    [DebuggerDisplay("Name = { Name }, Type = { Type }, Ordinal = { Ordinal }")]
    public class ColumnInternalMetadata(string name, string type, int ordinal) : IColumnInternalMetadata
    {
        private readonly Type _type = System.Type.GetType(type);

        /// <inheritdoc/>
        public string Name
        {
            get => name;
        }

        /// <inheritdoc/>
        public string Type
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
            return new DataColumn(name, _type);
        }
    }
}