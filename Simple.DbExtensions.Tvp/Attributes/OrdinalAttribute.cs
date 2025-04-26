using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public sealed class OrdinalAttribute(int ordinal) : Attribute
    {
        /// <inheritdoc cref="DataColumn.Ordinal"/>
        public int Ordinal
        {
            get => ordinal;
        }
    }
}