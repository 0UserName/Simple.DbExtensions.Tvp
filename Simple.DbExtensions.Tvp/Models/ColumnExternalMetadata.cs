using Simple.DbExtensions.Tvp.Models.Contracts;

using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Models
{
    public sealed class ColumnExternalMetadata : ColumnInternalMetadata, IColumnExternalMetadata
    {
        /// <inheritdoc/>
        public bool AllowDBNull
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public int MaxLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        private DataColumn SetAllowDBNull(DataColumn column)
        {
            column.AllowDBNull = AllowDBNull;

            return column;
        }

        /// <summary>
        /// Sets the maximum 
        /// length of a text 
        /// column.
        /// </summary>
        /// 
        /// <remarks>
        /// Applies to string data type only.
        /// </remarks>
        private DataColumn SetMaxLength(DataColumn column)
        {
            column.MaxLength = Type.FullName == "System.String" ? MaxLength : column.MaxLength;

            return column;
        }

        /// <inheritdoc/>
        public override DataColumn CreateColumn()
        {
            return SetMaxLength(SetAllowDBNull(base.CreateColumn()));
        }

        public ColumnExternalMetadata(string table, string name, string type, int ordinal, bool allowDBNull, short maxLength) : base(table, name, Type.GetType(type), ordinal)
        {
            AllowDBNull = allowDBNull;
            MaxLength   = maxLength;
        }
    }
}