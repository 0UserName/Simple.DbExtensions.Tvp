using Simple.DbExtensions.Tvp.Metadata.Contracts;

using System;

namespace Simple.DbExtensions.Tvp.Metadata.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = default)]
    public sealed class TableAttribute(string name) : Attribute, ITableMetadata
    {
        /// <inheritdoc/>
        public string Name
        {
            get => name;
        }

        /// <inheritdoc/>
        public int MaximumRetained
        {
            get;
            private set;
        }

        public TableAttribute(string name, int maximumRetained) : this(name)
        {
            MaximumRetained = maximumRetained;
        }
    }
}