using System;

namespace Simple.DbExtensions.Tvp.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public sealed class TableValuedPoolAttribute(int maximumRetained) : Attribute
    {
        /// <summary>
        /// The 
        /// maximum number of 
        /// objects to retain 
        /// in the pool.
        /// </summary>
        public int MaximumRetained
        {
            get => maximumRetained;
        }
    }
}