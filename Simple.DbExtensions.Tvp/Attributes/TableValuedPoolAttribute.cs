using System;

namespace Simple.DbExtensions.Tvp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = default)]
    public sealed class TableValuedPoolAttribute : Attribute
    {
        /// <summary>
        /// The 
        /// maximum number of 
        /// objects to retain 
        /// in the pool.
        /// </summary>
        public int MaximumRetained
        {
            get;
            private set;
        }

        public TableValuedPoolAttribute(int maximumRetained)
        {
            MaximumRetained = maximumRetained;
        }
    }
}