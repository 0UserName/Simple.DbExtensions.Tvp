using System;
using System.Data;

namespace Simple.DbExtensions.Tvp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = default)]
    public sealed class OrdinalAttribute : Attribute
    {
        /// <summary>
        /// Position of the column in 
        /// the <see cref="DataTable"/>.
        /// </summary>
        public int Ordinal
        {
            get;
            private set;
        }

        public OrdinalAttribute(int ordinal)
        {
            Ordinal = ordinal;
        }
    }
}