using Simple.DbExtensions.Tvp.Models.Contracts;

using System;

namespace Simple.DbExtensions.Tvp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = default)]
    public sealed class TableValuedAttribute : Attribute, ITableMetadata
    {
        /// <inheritdoc/>
        public string Name
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public bool CaseSensitive
        {
            get;
            private set;
        }

        public TableValuedAttribute(string name)
        {
            Name = name;
        }

        public TableValuedAttribute(string name, bool caseSensitive) : this(name)
        {
            CaseSensitive = caseSensitive;
        }
    }
}