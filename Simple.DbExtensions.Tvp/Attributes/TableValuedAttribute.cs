using Simple.DbExtensions.Tvp.Models.Contracts;

using System;

namespace Simple.DbExtensions.Tvp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = default)]
    public sealed class TableValuedAttribute(string name) : Attribute, ITableMetadata
    {
        /// <inheritdoc/>
        public string Name
        {
            get => name;
        }
    }
}