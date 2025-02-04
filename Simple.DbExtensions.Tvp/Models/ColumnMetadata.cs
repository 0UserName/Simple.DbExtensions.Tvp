using Simple.DbExtensions.Tvp.Models.Contracts;

using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Models
{
    internal class ColumnMetadata : IColumnMetadata
    {
        /// <summary>
        /// 
        /// </summary>
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
        public virtual DataColumn CreateColumn()
        {
            return new DataColumn(Name, Type);
        }

        public ColumnMetadata(string table, string name, Type type)
        {
            Table = table;

            Name = name;
            Type = type;
        }
    }
}