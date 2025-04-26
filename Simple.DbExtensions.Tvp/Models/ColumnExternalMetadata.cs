using Simple.DbExtensions.Tvp.Models.Contracts;

using System.Data;
using System.Data.SqlTypes;

using System.Diagnostics;

namespace Simple.DbExtensions.Tvp.Models
{
    [DebuggerDisplay("Name = { Name }, Type = { Type }, Ordinal = { Ordinal }, AllowDBNull = { AllowDBNull }, MaxLength = { MaxLength }, Unique = { Unique }")]
    public sealed class ColumnExternalMetadata(string table, string name, string type, int ordinal, bool allowDBNull, int maxLength, bool unique) : ColumnInternalMetadata(name, type, ordinal), IColumnExternalMetadata
    {
        /// <inheritdoc cref="ITableMetadata.Name"/>
        public string Table
        {
            get => table;
        }

        /// <inheritdoc/>
        public bool AllowDBNull
        {
            get => allowDBNull;
        }

        /// <inheritdoc/>
        public int MaxLength
        {
            get => maxLength;
        }

        /// <inheritdoc/>
        public bool Unique
        {
            get => unique;
        }

        /// <summary>
        /// 
        /// </summary>
        private DataColumn SetAllowDBNull(DataColumn column)
        {
            column.AllowDBNull = allowDBNull;

            return column;
        }

        /// <summary>
        /// Sets the maximum 
        /// length of a text 
        /// column.
        /// </summary>
        /// 
        /// <remarks>
        /// Applies to text data type only.
        /// </remarks>
        private DataColumn SetMaxLength(DataColumn column)
        {
            column.MaxLength = column.DataType == typeof(string) || column.DataType == typeof(SqlString) ? maxLength : column.MaxLength;

            return column;
        }

        /// <summary>
        /// 
        /// </summary>
        private DataColumn SetUnique(DataColumn column)
        {
            column.Unique = unique;

            return column;
        }

        /// <inheritdoc/>
        public override DataColumn CreateColumn()
        {
            return SetUnique(SetMaxLength(SetAllowDBNull(base.CreateColumn())));
        }
    }
}