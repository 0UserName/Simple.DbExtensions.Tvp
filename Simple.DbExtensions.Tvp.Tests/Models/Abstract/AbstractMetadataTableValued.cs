using Simple.DbExtensions.Tvp.Attributes;

using Simple.DbExtensions.Tvp.Models.Abstract;
using Simple.DbExtensions.Tvp.Models.Contracts;

namespace Simple.DbExtensions.Tvp.Tests.Models.Abstract
{
    public abstract class AbstractMetadataTableValued<TRow> : AbstractTableValued<TRow> where TRow : class, ITableValued
    {
        public virtual int? Property0
        {
            get;
            set;
        }

        public virtual int? Property1
        {
            get;
            set;
        }

        [Ordinal(3)]
        public virtual int Property2
        {
            get;
            set;
        }

        [Ordinal(2)]
        public virtual int Property3
        {
            get;
            set;
        }
    }
}